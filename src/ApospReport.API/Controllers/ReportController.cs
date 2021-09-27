using System.Threading.Tasks;
using ApospReport.API.Samples;
using ApospReport.Application.GetAccountReport;
using ApospReport.Application.GetItemImage;
using ApospReport.Application.GetTotalBankReport;
using ApospReport.Application.RemoveAccountReport;
using ApospReport.Application.SaveAccountReport;
using ApospReport.Contract;
using ApospReport.Contract.AccountReport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("account")]
        [SwaggerRequestExample(typeof(AccountReportDto), typeof(SaveAccountReportExample))]
        public async Task<IActionResult> Post([FromBody] AccountReportDto request)
        {
            await mediator.Send(new SaveAccountReportCommand(request));
            return Ok();
        }

        [HttpGet("account")]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetAccountReportQuery()));
        }

        [HttpDelete("account/{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            await mediator.Send(new RemoveAccountReportCommand(username));
            return Ok();

        }

        [HttpGet("bank")]
        public async Task<IActionResult> GetTotalBank()
        {
            return Ok(await mediator.Send(new GetTotalBankItemReportQuery()));
        }

        [HttpGet("item-images")]
        public async Task<IActionResult> GetItemImages()
        {
            return Ok(await mediator.Send(new GetItemImageQuery()));
        }
    }
}
