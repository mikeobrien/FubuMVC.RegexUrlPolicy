using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Reflection;

namespace FubuMVC.RegexUrlPolicy
{
    public class RegexUrlPolicyDsl
    {
        private static readonly Regex MatchAll = new Regex(".*");

        private readonly Configuration _configuration;

        public RegexUrlPolicyDsl(Configuration configuration)
        {
            _configuration = configuration;
        }

        public RegexUrlPolicyDsl IgnoreNamespace()
        {
            _configuration.SegmentPatterns.Add(new Configuration.SegmentPattern { Regex = MatchAll, Type = Configuration.Segment.Namespace });
            return this;
        }

        public RegexUrlPolicyDsl IgnoreNamespaces(params string[] patterns)
        {
            _configuration.IgnoreSegment(Configuration.Segment.Namespace, patterns);
            return this;
        }

        public RegexUrlPolicyDsl IgnoreNamespace(Type type)
        {
            return IgnoreNamespaces(type.Namespace);
        }

        public RegexUrlPolicyDsl IgnoreNamespace<T>()
        {
            return IgnoreNamespace(typeof(T));
        }

        public RegexUrlPolicyDsl IgnoreAssemblyNamespace(Type type)
        {
            return IgnoreNamespaces(Assembly.GetAssembly(type).GetName().Name);
        }

        public RegexUrlPolicyDsl IgnoreAssemblyNamespace<T>()
        {
            return IgnoreNamespaces(Assembly.GetAssembly(typeof(T)).GetName().Name);
        }

        public RegexUrlPolicyDsl IgnoreAssemblyNamespace()
        {
            return IgnoreNamespaces(Assembly.GetCallingAssembly().GetName().Name);
        }

        public RegexUrlPolicyDsl IgnoreClassName()
        {
            _configuration.SegmentPatterns.Add(new Configuration.SegmentPattern { Regex = MatchAll, Type = Configuration.Segment.Class });
            return this;
        }

        public RegexUrlPolicyDsl IgnoreClassNames(params string[] patterns)
        {
            _configuration.IgnoreSegment(Configuration.Segment.Class, patterns);
            return this;
        }

        public RegexUrlPolicyDsl IgnoreMethodName()
        {
            _configuration.SegmentPatterns.Add(new Configuration.SegmentPattern { Regex = MatchAll, Type = Configuration.Segment.Method });
            return this;
        }

        public RegexUrlPolicyDsl IgnoreMethodNames(params string[] patterns)
        {
            _configuration.IgnoreSegment(Configuration.Segment.Method, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToGet(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Namespace, patterns); 
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToPost(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Namespace, patterns); 
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToPut(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Namespace, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToUpdate(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Namespace, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToDelete(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Namespace, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToGetStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Namespace, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToPostStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Namespace, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToPutStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Namespace, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToUpdateStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Namespace, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToDeleteStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Namespace, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToGetEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Namespace, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToPostEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Namespace, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToPutEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Namespace, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToUpdateEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Namespace, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainNamespaceToDeleteEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Namespace, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToGet(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Class, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToPost(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Class, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToPut(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Class, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToUpdate(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Class, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToDelete(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Class, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToGetStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Class, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToPostStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Class, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToPutStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Class, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToUpdateStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Class, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToDeleteStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Class, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToGetEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Class, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToPostEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Class, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToPutEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Class, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToUpdateEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Class, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainClassToDeleteEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Class, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToGet(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Method, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToPost(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Method, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToPut(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Method, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToUpdate(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Method, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToDelete(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Method, patterns);
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToGetStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Class, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToPostStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Method, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToPutStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Method, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToUpdateStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Method, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToDeleteStartingWith(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Method, patterns.Select(RegexStartingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToGetEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToGet(Configuration.Segment.Class, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToPostEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToPost(Configuration.Segment.Method, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToPutEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToPut(Configuration.Segment.Method, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToUpdateEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToUpdate(Configuration.Segment.Method, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        public RegexUrlPolicyDsl ConstrainMethodToDeleteEndingWith(params string[] patterns)
        {
            _configuration.ConstrainToDelete(Configuration.Segment.Method, patterns.Select(RegexEndingWith).ToArray());
            return this;
        }

        private static string RegexStartingWith(string value)
        {
            return string.Format("^{0}.*", value);
        }

        private static string RegexEndingWith(string value)
        {
            return string.Format(".*{0}$", value);
        }
    }
}
