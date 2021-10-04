using ApospReport.API.Authentication;
using ApospReport.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ApospReport.API.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IApiKeyValidator apiKeyValidator;

        public AuthenticationController(IApiKeyValidator apiKeyValidator)
        {
            this.apiKeyValidator = apiKeyValidator;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationDto request)
        {
            return Ok(new { isValid = apiKeyValidator.IsValid(request.ApiKey) });
        }
    }
}
