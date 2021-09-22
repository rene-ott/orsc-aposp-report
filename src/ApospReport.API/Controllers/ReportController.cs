using System.Threading.Tasks;
using ApospReport.Application.SaveAccountReport;
using ApospReport.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApospReport.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountDto request)
        {
            await mediator.Send(new SaveAccountReportCommand(request));
            return Ok();
        }
    }
}
