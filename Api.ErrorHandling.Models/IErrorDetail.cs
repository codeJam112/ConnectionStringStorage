namespace Api.ErrorHandling.Models
{
    public interface IErrorDetail
    {
        string Code { get; set; }
        string Message { get; set; }
        string Target { get; set; }
    }
}