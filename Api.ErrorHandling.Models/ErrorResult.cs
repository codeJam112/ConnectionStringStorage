using System;

namespace Api.ErrorHandling.Models
{
    public class ErrorResult
    {
        public ErrorResult(ErrorCode errorCode, string message = null, Exception exception = null, Guid errorId = default(Guid))
        {
            ErrorCode = errorCode;
            Message = message;
            Exception = exception;
            ErrorId = Guid.NewGuid();
        }

        public Guid ErrorId { get; }
        public ErrorCode ErrorCode { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public static ErrorResult None = new ErrorResult(ErrorCode.NotAnError, "No error found", null, new Guid("1b5e0e80-4c57-4900-b962-66e26b5393f5"));
    }
}