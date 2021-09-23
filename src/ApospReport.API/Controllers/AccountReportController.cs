using System.Threading.Tasks;
using ApospReport.API.Samples;
using ApospReport.Application.SaveAccountReport;
using ApospReport.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API.Controllers
{
    [ApiController]
    [Route("api/account-report")]
    public class AccountReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [SwaggerRequestExample(typeof(AccountDto), typeof(SaveAccountReportExample))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountDto request)
        {
            await mediator.Send(new SaveAccountReportCommand(request));
            return Ok();
        }
    }
}
