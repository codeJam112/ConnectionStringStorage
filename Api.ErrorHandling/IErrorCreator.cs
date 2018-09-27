using System;
using System.Collections.Generic;
using Api.ErrorHandling.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.ErrorHandling
{
    public interface IErrorCreator
    {
        IError CreateApplicationError(IList<string> list, string correlationId, string errorCode = "Unspecified");
        IError CreateApplicationError(string errorMessage, string correlationId, string errorCode = "Unspecified");
        IError CreateValidationError(IList<string> list, string correlationId);
        IError CreateValidationError(string errorMessage, string correlationId);
        IError CreateValidationError(ModelStateDictionary modelState, string correlationId);
        IError CreateNotFound(int id, string correlationId);
    }
}