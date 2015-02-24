using System;
using System.IO;
using System.Linq;
using System.Web;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.DSL;
using FubuMVC.Core.Registration.Nodes;
using System.Web.Routing;

namespace FubuMVC.RegexUrlPolicy
{
    public static class Extensions
    {
        private const int MaxPathLength = 260;

        public static ActionSource IncludeTypeNamesSuffixed(this ActionSource source, params string[] suffix)
        {
            source.IncludeTypes(y => suffix.Any(z => y.Name.EndsWith(z)));
            return source;
        }

        public static ActionSource IncludeMethodsPrefixed(this ActionSource source, params string[] prefix)
        {
            source.IncludeMethods(y => prefix.Any(z => y.Name.StartsWith(z)));
            return source;
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

        private readonly static char[] InvalidPathChars = Path.GetInvalidPathChars().Concat(new[] {':'}).ToArray();

        public static bool IsValidPath(this string path)
        {
            return !string.IsNullOrEmpty(path) && path.Length <= MaxPathLength && !InvalidPathChars.Any(path.Contains);
        }

        public static bool CurrentRequestMapsToPhysicalFile(this HttpContextBase httpContext)
        {
            var path = httpContext.Request.CurrentExecutionFilePath;
            return path.IsValidPath() && File.Exists(httpContext.Server.MapPath(path));
        }

        private class IgnoreFilesRoute : Route
        {
            public IgnoreFilesRoute() : base(null, new StopRoutingHandler()) { }

            public override RouteData GetRouteData(HttpContextBase httpContext)
            {
                return httpContext.CurrentRequestMapsToPhysicalFile() ?
                    new RouteData(this, RouteHandler) : null;
            }

            public override VirtualPathData GetVirtualPath(
                RequestContext requestContext, 
                RouteValueDictionary routeValues)
            {
                return null;
            }
        }
    }
}
