using System.Web;
using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace FubuMVC.RegexUrlPolicy
{
    [ConfigurationType(ConfigurationType.Policy)]
    public class DefaultDocument : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            var route = new RouteDefinition("");
            route.AddHttpMethodConstraint("GET");
            var chain = new BehaviorChain { Route = route };
            chain.AddToEnd(new RedirectNode());
            graph.AddChain(chain);
            graph.Services.AddService(this);
        }

        public string Url { get; set; }

        public class RedirectNode : Wrapper
        {
            public RedirectNode() : base(typeof(RedirectBehavior)) { }
        }

        public class RedirectBehavior : IActionBehavior
        {
            private readonly DefaultDocument _defaultDocument;

            public RedirectBehavior(DefaultDocument defaultDocument)
            {
                _defaultDocument = defaultDocument;
            }

            public void Invoke()
            {
                HttpContext.Current.Server.Transfer(_defaultDocument.Url);
            }

            public void InvokePartial() { }
        }
    }
}
