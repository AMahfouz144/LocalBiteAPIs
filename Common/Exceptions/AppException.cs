using System;

namespace Common
{
    public class AppException : Exception
    {
        public string ClientMessage { set; get; }
        public int StatusCode { protected set; get; }
        public ExceptionType Type { set; get; }

        public AppException(ExceptionType type)
        {
            this.Type = type;
        }

        public AppException(string message)
            : base(message)
        {

        }
    }
}