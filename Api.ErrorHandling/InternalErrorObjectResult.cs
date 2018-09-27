using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.ErrorHandling
{
    public class InternalErrorObjectResult : ObjectResult
    {
        public InternalErrorObjectResult(object error)
            : base(error)
        {
            this.StatusCode = new int?(500);
        }

        public InternalErrorObjectResult(ModelStateDictionary modelState)
            : base((object)new SerializableError(modelState))
        {
            if (modelState == null)
                throw new ArgumentNullException(nameof(modelState));
            this.StatusCode = new int?(500);
        }
    }
}