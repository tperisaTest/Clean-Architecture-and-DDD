using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.API.Filters
{
    public class ErrorHandlingFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred while processing your request.",
                Status = (int)HttpStatusCode.InternalServerError
            };

            context.Result = new ObjectResult(problemDetails);
            context.ExceptionHandled = true;
        }
    }
}
