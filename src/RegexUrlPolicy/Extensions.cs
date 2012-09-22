using System;
using System.Linq;
using System.Reflection;
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
            suffix.ToList().ForEach(x => expression.IncludeTypes(y => y.Name.EndsWith(x)));
            return expression;
        }

        public static ActionCallCandidateExpression IncludeMethodsPrefixed(this ActionCallCandidateExpression expression, params string[] prefix)
        {
            prefix.ToList().ForEach(x => expression.IncludeMethods(y => y.Name.StartsWith(x)));
            return expression;
        }

        public static bool IsInThisAssembly(this ActionCall call)
        {
            return call.HandlerType.Assembly == Assembly.GetCallingAssembly();
        }

        public static bool IsInAssembly<T>(this ActionCall call)
        {
            return call.IsInAssembly(typeof(T));
        }

        public static bool IsInAssembly(this ActionCall call, Type type)
        {
            return call.HandlerType.Assembly == type.Assembly;
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
