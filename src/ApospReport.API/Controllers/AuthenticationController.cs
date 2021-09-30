using System.Threading.Tasks;
using ApospReport.API.Authentication;
using ApospReport.API.Samples;
using ApospReport.Contract;
using ApospReport.Contract.AccountReport;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

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
        [SwaggerRequestExample(typeof(AccountReportDto), typeof(SaveAccountReportExample))]
        public IActionResult Authenticate([FromBody] AuthenticationDto request)
        {
            return Ok(new { isValid = apiKeyValidator.IsValid(request.ApiKey) });
        }
    }
}
