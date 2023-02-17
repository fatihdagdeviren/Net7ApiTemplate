using Application.CQRS.Queries.Request;
using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Net7ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ZoneCQRSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetList")]
        public async Task<ActionResult<ApiResult<bool>>> GetList()
        {
            var response = await _mediator.Send(new GetAllZonesQueryRequest());
            return null;
        }
    }
}
