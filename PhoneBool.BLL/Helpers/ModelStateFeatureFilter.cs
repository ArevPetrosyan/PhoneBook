using Ardalis.Result;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.BLL.Helpers
{
    public class ModelStateFeatureFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var state = context.ModelState;

            if (!state.IsValid)
            {
                var validationErrorList = new List<ValidationError>();
                foreach (var error in state)
                {
                    foreach (var err in error.Value.Errors)
                    {
                        validationErrorList.Add(new ValidationError()
                        {
                            ErrorCode = null,
                            ErrorMessage = err.ErrorMessage,
                            Identifier = error.Key
                        });
                    }
                }

                context.Result = new JsonResult(Result.Invalid(validationErrorList));
                context.HttpContext.Response.StatusCode = 400;
                return;
            }

            await next();
        }
    }
}
