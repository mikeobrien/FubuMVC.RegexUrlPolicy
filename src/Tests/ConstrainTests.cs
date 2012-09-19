using FubuMVC.RegexUrlPolicy;
using NUnit.Framework;
using Should;
using Web.Handlers;

namespace Tests
{
    [TestFixture]
    public class ConstrainTests
    {
        [Test]
        public void should_constrain_to_get_by_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainNamespaceToGet("Web"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("GET");
        }

        [Test]
        public void should_constrain_to_post_by_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainNamespaceToPost("Web"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("POST");
        }

        [Test]
        public void should_constrain_to_put_by_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainNamespaceToPut("Web"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("PUT");
        }

        [Test]
        public void should_constrain_to_update_by_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainNamespaceToUpdate("Web"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("UPDATE");
        }

        [Test]
        public void should_constrain_to_delete_by_namespace()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainNamespaceToDelete("Web"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("DELETE");
        }

        [Test]
        public void should_constrain_to_get_by_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToGet("Get"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("GET");
        }

        [Test]
        public void should_constrain_to_post_by_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToPost("Post"))
                .CreateRoute<PostHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("POST");
        }

        [Test]
        public void should_constrain_to_put_by_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToPut("Put"))
                .CreateRoute<PutHandler>(x => x.ExecutePut());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("PUT");
        }

        [Test]
        public void should_constrain_to_update_by_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToUpdate("Update"))
                .CreateRoute<UpdateHandler>(x => x.ExecuteUpdate());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("UPDATE");
        }

        [Test]
        public void should_constrain_to_delete_by_class_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToDelete("Delete"))
                .CreateRoute<DeleteHandler>(x => x.ExecuteDelete());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("DELETE");
        }

        [Test]
        public void should_constrain_to_get_by_class_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToGetStartingWith("Get"))
                .CreateRoute<GetUserHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("GET");
        }

        [Test]
        public void should_constrain_to_post_by_class_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToPostStartingWith("Post"))
                .CreateRoute<PostUserHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("POST");
        }

        [Test]
        public void should_constrain_to_put_by_class_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToPutStartingWith("Put"))
                .CreateRoute<PutUserHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("PUT");
        }

        [Test]
        public void should_constrain_to_update_by_class_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToUpdateStartingWith("Update"))
                .CreateRoute<UpdateUserHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("UPDATE");
        }

        [Test]
        public void should_constrain_to_delete_by_class_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToDeleteStartingWith("Delete"))
                .CreateRoute<DeleteUserHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("DELETE");
        }

        [Test]
        public void should_constrain_to_get_by_class_name_ending_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToGetEndingWith("GetHandler"))
                .CreateRoute<UserGetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("GET");
        }

        [Test]
        public void should_constrain_to_post_by_class_name_ending_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToPostEndingWith("PostHandler"))
                .CreateRoute<UserPostHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("POST");
        }

        [Test]
        public void should_constrain_to_put_by_class_name_ending_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToPutEndingWith("PutHandler"))
                .CreateRoute<UserPutHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("PUT");
        }

        [Test]
        public void should_constrain_to_update_by_class_name_ending_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToUpdateEndingWith("UpdateHandler"))
                .CreateRoute<UserUpdateHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("UPDATE");
        }

        [Test]
        public void should_constrain_to_delete_by_class_name_ending_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainClassToDeleteEndingWith("DeleteHandler"))
                .CreateRoute<UserDeleteHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("DELETE");
        }

        [Test]
        public void should_constrain_to_get_by_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToGet("Execute"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("GET");
        }

        [Test]
        public void should_constrain_to_post_by_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToPost("Execute"))
                .CreateRoute<PostHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("POST");
        }

        [Test]
        public void should_constrain_to_put_by_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToPut("Put"))
                .CreateRoute<PutHandler>(x => x.ExecutePut());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("PUT");
        }

        [Test]
        public void should_constrain_to_update_by_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToUpdate("Update"))
                .CreateRoute<UpdateHandler>(x => x.ExecuteUpdate());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("UPDATE");
        }

        [Test]
        public void should_constrain_to_delete_by_method_name()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToDelete("Delete"))
                .CreateRoute<DeleteHandler>(x => x.ExecuteDelete());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("DELETE");
        }

        [Test]
        public void should_constrain_to_get_by_method_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToGet("Execute"))
                .CreateRoute<GetHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("GET");
        }

        [Test]
        public void should_constrain_to_post_by_method_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToPost("Execute"))
                .CreateRoute<PostHandler>(x => x.Execute());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("POST");
        }

        [Test]
        public void should_constrain_to_put_by_method_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToPut("Put"))
                .CreateRoute<PutHandler>(x => x.ExecutePut());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("PUT");
        }

        [Test]
        public void should_constrain_to_update_by_method_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToUpdate("Update"))
                .CreateRoute<UpdateHandler>(x => x.ExecuteUpdate());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("UPDATE");
        }

        [Test]
        public void should_constrain_to_delete_by_method_name_starting_with()
        {
            var route = RegexUrlPolicy.Create(x => x.ConstrainMethodToDelete("Delete"))
                .CreateRoute<DeleteHandler>(x => x.ExecuteDelete());
            route.AllowedHttpMethods.Count.ShouldEqual(1);
            route.AllowedHttpMethods.ShouldContain("DELETE");
        }
    } 
}