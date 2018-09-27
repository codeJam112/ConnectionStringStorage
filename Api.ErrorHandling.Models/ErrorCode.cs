namespace Api.ErrorHandling.Models
{
    public enum ErrorCode
    {
        NotAnError = 0,
        UnableToCreatePlatform = 1,
        UnableToUpdatePlatform = 2,
        InvalidPlatformId = 3,
        UnableToReadPlatform = 4,
        UnableToDeletePlatform
    }
}