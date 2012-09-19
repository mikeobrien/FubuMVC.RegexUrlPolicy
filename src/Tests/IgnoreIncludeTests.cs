using FubuMVC.RegexUrlPolicy;
using NUnit.Framework;
using Should;
using Web.Handlers;
using Web.Handlers_Name;

namespace Tests
{
    [TestFixture]
    public class IgnoreIncludeTests
    {
        [Test]
        public void default_should_include_namespace_class_and_method_for_all_http_methods()
        {
            var route = RegexUrlPolicy.Create().CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.ShouldBeEmpty();
            route.Pattern.ShouldEqual("web/handlers/gethandler/execute");
        }

        [Test]
        public void should_ignore_entire_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreNamespace())
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("gethandler/execute");
        }

        [Test]
        public void should_ignore_current_assembly_namespace_of_type()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreAssemblyNamespace(typeof(IgnoreIncludeTests)))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/execute");
        }

        [Test]
        public void should_ignore_current_assembly_namespace_of_generic_type()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreAssemblyNamespace<IgnoreIncludeTests>())
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/execute");
        }

        [Test]
        public void should_ignore_current_assembly()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreAssemblyNamespace<IgnoreIncludeTests>())
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/execute");
        }

        [Test]
        public void should_ignore_type_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreNamespace<IgnoreIncludeTests>())
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/execute");
        }

        [Test]
        public void should_ignore_custom_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreNamespaces("Web.Handlers"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("gethandler/execute");
        }

        [Test]
        public void should_ignore_custom_regex_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreNamespaces("H.*?s"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/gethandler/execute");
        }

        [Test]
        public void should_ignore_multiple_custom_regex_namespaces()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreNamespaces("H.*?d", "ers"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/l/gethandler/execute");
        }

        [Test]
        public void should_ignore_entire_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreClassName())
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/execute");
        }

        [Test]
        public void should_ignore_custom_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreClassNames("Handler"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/get/execute");
        }

        [Test]
        public void should_ignore_custom_regex_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreClassNames("H.*?r"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/get/execute");
        }

        [Test]
        public void should_ignore_multiple_custom_regex_class_names()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreClassNames("H.*?d", "l.*$"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/get/execute");
        }

        [Test]
        public void should_ignore_entire_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreMethodName())
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler");
        }

        [Test]
        public void should_ignore_custom_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreMethodNames("cute"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/exe");
        }

        [Test]
        public void should_ignore_custom_regex_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreMethodNames("c.*$"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/exe");
        }

        [Test]
        public void should_ignore_multiple_custom_regex_method_names()
        {
            var route = RegexUrlPolicy.Create(x => x.IgnoreMethodNames("^.*?e", "u.*$"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.Pattern.ShouldEqual("web/handlers/gethandler/c");
        }

        [Test]
        public void should_include_url_parameters()
        {
            RegexUrlPolicy.Create().CreateRoute<GetByIdAndNameHandler>(x => x.Execute_Id_Name(null))
                .Pattern.ShouldEqual("web/handlers/getbyidandnamehandler/execute/{Id}/{Name}");
        }

        [Test]
        public void should_include_class_url_parameters()
        {
            RegexUrlPolicy.Create().CreateRoute<Widget_Name_GetHandler>(x => x.Execute_Id(null))
                .Pattern.ShouldEqual("web/handlers/widget/{Name}/gethandler/execute/{Id}");
        }

        [Test]
        public void should_include_namespace_url_parameters()
        {
            RegexUrlPolicy.Create().CreateRoute<WidgetGetHandler>(x => x.Execute_Id(null))
                .Pattern.ShouldEqual("web/handlers/{Name}/widgetgethandler/execute/{Id}");
        }
    }
}
