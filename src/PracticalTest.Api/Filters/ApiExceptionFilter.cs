using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PracticalTestApi.Exceptions;
using PracticalTestApi.Services.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PracticalTestApi.Filters
{
    public class ApiExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            if (ex is ValidationException)
            {
                // Todo: Format message details.
                 ErrorResult(400, new ErrorDto { Message = ex.Message, Details = { } });
            }
            else if (ex is DomainNotFoundException)
            {
                context.Result = new NotFoundResult();
            }
        }

        private static IActionResult ErrorResult(int statusCode, ErrorDto error)
        {
            error.StatusCode = statusCode;

            return new ObjectResult(error) { StatusCode = statusCode };
        }
    }
}
