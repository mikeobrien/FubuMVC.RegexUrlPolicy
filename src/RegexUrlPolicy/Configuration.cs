using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FubuMVC.RegexUrlPolicy
{
    public class Configuration
    {
        public enum Segment { Namespace, Class, Method }

        public class SegmentPattern
        {
            public Segment Type { get; set; }
            public Regex Regex { get; set; }
        }

        public class HttpConstraintPattern : SegmentPattern
        {
            public string Method { get; set; }
        }

        public readonly List<SegmentPattern> SegmentPatterns = new List<SegmentPattern>();
        public readonly List<HttpConstraintPattern> HttpConstraintPatterns = new List<HttpConstraintPattern>();

        public void ConstrainToGet(Segment segment, params string[] patterns)
        { ConstrainSegmentToHttpMethod(segment, "GET", patterns); }

        public void ConstrainToPost(Segment segment, params string[] patterns)
        { ConstrainSegmentToHttpMethod(segment, "POST", patterns); }

        public void ConstrainToPut(Segment segment, params string[] patterns)
        { ConstrainSegmentToHttpMethod(segment, "PUT", patterns); }

        public void ConstrainToDelete(Segment segment, params string[] patterns)
        { ConstrainSegmentToHttpMethod(segment, "DELETE", patterns); }

        public void ConstrainToUpdate(Segment segment, params string[] patterns)
        { ConstrainSegmentToHttpMethod(segment, "UPDATE", patterns); }

        public void ConstrainSegmentToHttpMethod(Segment segment, string method, params string[] patterns)
        {
            HttpConstraintPatterns.AddRange(patterns.Select(x =>
                new HttpConstraintPattern { Type = segment, Method = method, Regex = new Regex(x) }));
        }

        public void IgnoreSegment(Segment segment, params string[] patterns)
        {
            if (patterns.Any())
                SegmentPatterns.AddRange(
                    patterns.Select(x => new SegmentPattern
                    {
                        Regex = new Regex(x),
                        Type = segment
                    }));
        }
    }
}