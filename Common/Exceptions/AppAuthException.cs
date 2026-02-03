namespace Common
{
    public class AppAuthException : AppException
    {
        public AuthExceptionType AuthExceptionType { set; get; }

        public AppAuthException()
            : base(ExceptionType.Auth)
        {
            StatusCode = 451; //Unavailable For Legal Reasons //Need to refresh
        }

        public AppAuthException(string message, AuthExceptionType type)
            : this()
        {
            this.ClientMessage = message;
            this.AuthExceptionType = type;
        }
    }
}