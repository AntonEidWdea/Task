using Application.Feature.BalanceFeature.Command.Post;
using Application.Feature.BalanceFeature.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BalanceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<PostBalanceResponse> Post(PostBalanceRequest request)
        {
            return await _mediator.Send(new PostBalanceCommand(request));
        }
        [HttpGet]
        public async Task<GetAllBalanceResponse> Get()
        {
            return await _mediator.Send(new GetAllBalanceQuery());
        }
    }
}
