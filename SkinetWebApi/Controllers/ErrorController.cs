using Microsoft.AspNetCore.Mvc;
using SkinetWebApi.Errors;

namespace SkinetWebApi.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    public class ErrorController : BaseController
    {
        public IActionResult Error(int statusCode)
        {
            return new ObjectResult(new ApiErrorResponse(statusCode));
        }
    }
}
