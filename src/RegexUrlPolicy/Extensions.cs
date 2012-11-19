using System.Linq;
using System.Web;
using System.Web.Hosting;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Registration.DSL;
using FubuMVC.Core.Registration.Nodes;
using System.Web.Routing;

namespace FubuMVC.RegexUrlPolicy
{
    public static class Extensions
    {
        public static ActionCallCandidateExpression IncludeTypeNamesSuffixed(this ActionCallCandidateExpression expression, params string[] suffix)
        {
            return expression.FindBy(x => x.IncludeTypes(y => suffix.Any(z => y.Name.EndsWith(z))));
        }

        public static ActionCallCandidateExpression IncludeMethodsPrefixed(this ActionCallCandidateExpression expression, params string[] prefix)
        {
            return expression.FindBy(x => x.IncludeMethods(y => prefix.Any(z => y.Name.StartsWith(z))));
        }

        public static bool IsContinuation(this ActionCall call)
        {
            return call.Method.ReturnType == typeof(FubuContinuation);
        }

        public static RouteConventionExpression OverrideFolders(this RouteConventionExpression routeConvention)
        {
            RouteTable.Routes.Add(new IgnoreFilesRoute());
            RouteTable.Routes.RouteExistingFiles = true;
            return routeConvention;
        }

        private class IgnoreFilesRoute : Route
        {
            public IgnoreFilesRoute() : base(null, new StopRoutingHandler()) { }

            public override RouteData GetRouteData(HttpContextBase httpContext)
            {
                return HostingEnvironment.VirtualPathProvider.FileExists(httpContext.Request.AppRelativeCurrentExecutionFilePath) ?
                    new RouteData(this, RouteHandler) : null;
            }

            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary routeValues)
            {
                return null;
            }
        }
    }
}
