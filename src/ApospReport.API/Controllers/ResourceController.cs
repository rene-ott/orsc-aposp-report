using System.Threading.Tasks;
using ApospReport.Application.GetItemImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApospReport.API.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {
        private readonly IMediator mediator;

        public ResourceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("item-images")]
        public async Task<IActionResult> GetItemImages()
        {
            return Ok(await mediator.Send(new GetItemImageQuery()));
        }
    }
}
