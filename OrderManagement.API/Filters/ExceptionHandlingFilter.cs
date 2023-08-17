using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderManagement.Core.Exceptions;

namespace OrderManagement.API.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is FluentValidation.ValidationException exception)
            {
                var errors = exception.Errors.Select(e => new
                {
                    e.PropertyName,
                    e.ErrorMessage
                });

                context.Result = new BadRequestObjectResult(errors);
                context.ExceptionHandled = true;
            }
            else if (context.Exception is DomainException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
            else if(context.Exception is NotFoundException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
            }
        }
    }
}
