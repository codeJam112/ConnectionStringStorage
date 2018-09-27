using System.Collections.Generic;

namespace Api.ErrorHandling.Models
{
    public interface IError
    {
        string ErrorCode { get; set; }
        string ErrorMessage { get; set; }
        string DisplayMessage { get; set; }
        string Target { get; set; }
        IError InnerError { get; set; }
        IEnumerable<IErrorDetail> ErrorDetails { get; set; }

    }
}