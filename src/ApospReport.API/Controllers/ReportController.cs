using System.Threading.Tasks;
using ApospReport.API.Samples;
using ApospReport.Application.GetAccountReport;
using ApospReport.Application.GetBankReport;
using ApospReport.Application.RemoveAccountReport;
using ApospReport.Application.SaveAccountReport;
using ApospReport.Contract.AccountReport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("account")]
        [SwaggerRequestExample(typeof(AccountReportDto), typeof(SaveAccountReportExample))]
        public async Task<IActionResult> SaveAccountReport([FromBody] AccountReportDto request)
        {
            await mediator.Send(new SaveAccountReportCommand(request));
            return Ok();
        }

        [HttpDelete("account/{username}")]
        public async Task<IActionResult> RemoveAccountReport(string username)
        {
            await mediator.Send(new RemoveAccountReportCommand(username));
            return Ok();
        }

        [HttpGet("account")]
        public async Task<IActionResult> GetAccountReports() =>
            Ok(await mediator.Send(new GetAccountReportQuery()));

        [HttpGet("bank")]
        public async Task<IActionResult> GetBankReport()
        {
            return Ok(await mediator.Send(new GetTotalBankItemReportQuery()));
        }
    }
}
