using System;
using System.Collections.Generic;
using System.Linq;
using Api.ErrorHandling.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.ErrorHandling
{
    public class ErrorCreator : IErrorCreator
    {
        public IError CreateValidationError(string errorMessage, string correlationId)
        {
            return CreateValidationError(new List<string> { errorMessage }, correlationId);
        }

        public IError CreateValidationError(IList<string> list, string correlationId)
        {
            var error = new Error()
            {
                ErrorMessage = "Invalid parameters",
                CorrelationId = correlationId,
                ErrorDetails = list.Select(e => new ErrorDetail()
                {
                    Message = e
                }).ToList()
            };

            return error;
        }

        public IError CreateValidationError(ModelStateDictionary modelState, string correlationId)
        {
            var error = new Error()
            {
                ErrorMessage = "Validation error",
                CorrelationId = correlationId,
                ErrorDetails = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ErrorDetail
                    {
                        Target = key,
                        Message = string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception.Message : x.ErrorMessage,
                        Code = "parameter"
                    })).ToList()
            };

            return error;
        }

        public IError CreateApplicationError(string errorMessage, string correlationId, string errorCode = "Unspecified")
        {
            return CreateApplicationError(new List<string> { errorMessage }, correlationId);
        }

        public IError CreateApplicationError(IList<string> list, string correlationId, string errorCode = "Unspecified")
        {
            var error = new Error()
            {
                ErrorCode = errorCode,
                ErrorMessage = "Unexpected anomaly",
                CorrelationId = correlationId,
                ErrorDetails = list.Select(e => new ErrorDetail()
                {
                    Message = e
                }).ToList()
            };

            return error;
        }

        public IError CreateNotFound(int id, string correlationId)
        {
            var error = new Error()
            {
                CorrelationId = correlationId,
                ErrorMessage = $"Not found for id:{id}"
            };

            return error;
        }
    }
}
