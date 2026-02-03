using System.Collections.Generic;

namespace Common.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }

        public ApiResponse()
        {
            Result = default(T);
            Message = "Done";
            Success = true;
            StatusCode = 200;
        }

        public ApiResponse(T resultObject) : this()
        {
            Result = resultObject;
        }
        public ApiResponse(string message, List<string> errors = null, int statusCode = 400)
        {
            Success = false;
            Message = message;
            Errors = errors ?? new List<string> { message };
            StatusCode = statusCode;
        }

        public static implicit operator ApiResponse<T>(T result)
        {
            return new ApiResponse<T>(result);
        }

        public static ApiResponse<T> Fail(string message, int statusCode = 400, List<string> errors = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors ?? new List<string> { message },
                StatusCode = statusCode
            };
        }
    }

    public class ApiResponse : ApiResponse<object>
    {
        public static new ApiResponse Void => new ApiResponse
        {
            Success = true,
            Message = "Done",
            StatusCode = 200
        };

        public ApiResponse()
        {
        }

        public ApiResponse(string message, List<string> errors = null, int statusCode = 400)
        : base(message, errors, statusCode) { }
    }
}
