using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.ErrorHandling
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly IErrorCreator _errorCreator;

        public ValidateModelAttribute() : this(new ErrorCreator())
        {
        }

        public ValidateModelAttribute(IErrorCreator errorCreator)
        {
            _errorCreator = errorCreator;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(_errorCreator.CreateValidationError(context.ModelState, context.HttpContext.TraceIdentifier));
            }
        }
    }
}