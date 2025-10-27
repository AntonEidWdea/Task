using Application.Feature.BalanceHistoryFeature.Query.GetByAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BalanceHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetHistorByAccountIdResponse> Get([FromQuery] GetHistorByAccountIdRequest dto)
        {
            return await _mediator.Send(new GetHistorByAccountIdQuery(dto));
        }
    }
}
