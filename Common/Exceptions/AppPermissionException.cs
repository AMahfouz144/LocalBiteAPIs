namespace Common
{
    public class AppPermissionException : AppException
    {
        public AppPermissionException()
            : base(ExceptionType.Permission)
        {
            StatusCode = 403;
            ClientMessage = "Sorry, You don't have a permission to do this action.";
        }

        public AppPermissionException(string action)
            : this()
        {
            this.ClientMessage = $"Sorry, You don't have a permission to {action}";
        }
    }
}