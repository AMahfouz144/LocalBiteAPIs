namespace Common
{
    public class AppBusinessException : AppException
    {
        public string BusinessRule { set; get; }

        public AppBusinessException()
            : base(ExceptionType.Business)
        {
            StatusCode = 406;
        }

        public AppBusinessException(string clientMessage, string businessRule)
            : this()
        {
            this.ClientMessage = clientMessage;
            this.BusinessRule = businessRule;
        }
    }
}