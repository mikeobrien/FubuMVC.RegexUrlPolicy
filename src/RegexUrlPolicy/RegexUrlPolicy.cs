using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using FubuCore.Reflection;
using FubuMVC.Core.Diagnostics;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace FubuMVC.RegexUrlPolicy
{
    public class RegexUrlPolicy : IUrlPolicy
    {
        private readonly Func<ActionCall, bool> _matchFilter;
        private readonly Configuration _configuration;

        public RegexUrlPolicy(Func<ActionCall, bool> matchFilter, Configuration configuration)
        {
            _matchFilter = matchFilter;
            _configuration = configuration;
        }

        public static RegexUrlPolicy Create()
        {
            return Create(x => true, null);
        }

        public static RegexUrlPolicy Create(Action<RegexUrlPolicyDsl> configure)
        {
            return Create(x => true, configure);
        }

        public static RegexUrlPolicy Create(Func<ActionCall, bool> matchFilter, Action<RegexUrlPolicyDsl> configure)
        {
            var configuration = new Configuration();
            if (configure != null) configure(new RegexUrlPolicyDsl(configuration));
            return new RegexUrlPolicy(matchFilter, configuration);
        }

        public bool Matches(ActionCall call, IConfigurationObserver log)
        {
            return _matchFilter(call);
        }

        public IRouteDefinition Build(ActionCall call)
        {
            var route = call.ToRouteDefinition();
            var properties = (call.HasInput ? new TypeDescriptorCache().GetPropertiesFor(call.InputType()).Values : Enumerable.Empty<PropertyInfo>()).ToList();
            AppendNamespace(route, call, properties, _configuration.SegmentPatterns.Where(x => x.Type == Configuration.Segment.Namespace).Select(x => x.Regex));
            AppendClass(route, call, properties, _configuration.SegmentPatterns.Where(x => x.Type == Configuration.Segment.Class).Select(x => x.Regex));
            AppendMethod(route, call, properties, _configuration.SegmentPatterns.Where(x => x.Type == Configuration.Segment.Method).Select(x => x.Regex));
            ConstrainToHttpMethod(route, call, _configuration.HttpConstraintPatterns);
            return route;
        }

        private static void ConstrainToHttpMethod(
            IRouteDefinition route, ActionCallBase call, IEnumerable<Configuration.HttpConstraintPattern> patterns)
        {
            Func<Configuration.Segment, string> getName = s =>
            {
                switch (s)
                {
                    case Configuration.Segment.Namespace: return call.HandlerType.Namespace;
                    case Configuration.Segment.Class: return call.HandlerType.Name;
                    case Configuration.Segment.Method: return call.Method.Name;
                } return null;
            };
            patterns.Where(x => x.Regex.IsMatch(getName(x.Type))).ToList().
                        ForEach(x => route.AddHttpMethodConstraint(x.Method));
        }

        private static void AppendNamespace(IRouteDefinition route, ActionCallBase call, IEnumerable<PropertyInfo> properties, IEnumerable<Regex> ignore)
        {
            var parts = RemovePattern(call.HandlerType.Namespace, ignore).Split('.').ToArray();
            Append(route, properties, parts);
        }

        private static void AppendClass(IRouteDefinition route, ActionCallBase call, IEnumerable<PropertyInfo> properties, IEnumerable<Regex> ignore)
        {
            var part = RemovePattern(call.HandlerType.Name, ignore);
            Append(route, properties, part);
        }

        private static void AppendMethod(IRouteDefinition route, ActionCallBase call, IEnumerable<PropertyInfo> properties, IEnumerable<Regex> ignore)
        {
            var part = RemovePattern(call.Method.Name, ignore);
            Append(route, properties, part);
            if (call.HasInput) route.ApplyInputType(call.InputType());
        }

        private static string RemovePattern(string source, IEnumerable<Regex> pattern)
        {
            return pattern.Aggregate(source, (a, i) => i.Replace(a, string.Empty));
        }

        private static void Append(IRouteDefinition route, IEnumerable<PropertyInfo> properties, params string[] parts)
        {
            var url = parts.Select(x => x.Split('_').Select(y => properties.Select(z => z.Name).Contains(y) ? "{" + y + "}" : y.ToLower()))
                .Select(x => x.Where(y => !string.IsNullOrEmpty(y)).Join("/"))
                .Where(x => !string.IsNullOrEmpty(x)).ToList();
            if (url.Any()) route.Append(url.Join("/"));
        }
    }
}