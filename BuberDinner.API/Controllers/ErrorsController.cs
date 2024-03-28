using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("/error")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            //var (statusCode, message) = exception switch
            //{
            //    DuplicateEmailError => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            //    _ => (StatusCodes.Status500InternalServerError, "An unexpected error has occured")
            //};
            return Problem(/*statusCode: statusCode, detail: message*/);
        }
    }
}