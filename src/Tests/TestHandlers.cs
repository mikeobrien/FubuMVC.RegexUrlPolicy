using Web.Handlers;

namespace Web.Handlers
{
    public class InputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetHandler { public object Execute() { return null; } }
    public class GetByIdAndNameHandler { public object Execute_Id_Name(InputModel model) { return null; } }
    public class Widget_Name_GetHandler { public object Execute_Id(InputModel model) { return null; } }
    public class PostHandler { public object Execute() { return null; } }
    public class PutHandler { public object ExecutePut() { return null; } }
    public class UpdateHandler { public object ExecuteUpdate() { return null; } }
    public class DeleteHandler { public object ExecuteDelete() { return null; } }
    public class GetUserHandler { public object Execute() { return null; } }
    public class PostUserHandler { public object Execute() { return null; } }
    public class PutUserHandler { public object Execute() { return null; } }
    public class UpdateUserHandler { public object Execute() { return null; } }
    public class DeleteUserHandler { public object Execute() { return null; } }
    public class UserGetHandler { public object Execute() { return null; } }
    public class UserPostHandler { public object Execute() { return null; } }
    public class UserPutHandler { public object Execute() { return null; } }
    public class UserUpdateHandler { public object Execute() { return null; } }
    public class UserDeleteHandler { public object Execute() { return null; } }
}

namespace Web.Handlers_Name
{
    public class WidgetGetHandler { public object Execute_Id(InputModel model) { return null; } }
}