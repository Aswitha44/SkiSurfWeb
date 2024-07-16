using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiSurf.API.Errors;

namespace SkiSurf.API.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code) {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
