using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PracticalTestApi.Exceptions;

namespace PracticalTestApi.Filters
{
    public class NotFoundFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {   public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainNotFoundException)
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}
