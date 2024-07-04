using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using SkinetWebApi.Errors;

namespace SkinetWebApi.Controllers
{
    public class ErrorTestController : BaseController
    {
        private readonly SkinetDbContext _dbContext;

        public ErrorTestController(SkinetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("NotFound")]
        public IActionResult GetNotFoundRequest()
        {
            var nullResult = _dbContext.Products.SingleOrDefault(x => x.Id == 1010101);

            if(nullResult == null)
            {
                return NotFound(new ApiErrorResponse(404));
            }

            return Ok();
        }

        [HttpGet]
        [Route("ServerError")]
        public IActionResult GetServerError()
        {
            var nullResult = _dbContext.Products.SingleOrDefault(x => x.Id == 1010101);

            var nullResultToString = nullResult.ToString();

            return Ok();
        }

        [HttpGet]
        [Route("Badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }

        [HttpGet]
        [Route("Badrequest/{id}")]
        public IActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}
