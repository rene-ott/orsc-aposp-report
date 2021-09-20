using ApospReport.Application.SaveReport;
using ApospReport.Contract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Post([FromBody] ReportDto request)
        {
            mediator.Send(new SaveReportCommand(request));
            return Ok();
        }
    }
}
