using Ardalis.Result;
using MediatR;

namespace Application.Feature.BalanceFeature.Command.Post
{
    public class PostBalanceCommand : IRequest<Result<PostBalanceResponse>>
    {
        public PostBalanceRequest dto { get; set; }
        public PostBalanceCommand(PostBalanceRequest DTO)
        {
            dto = DTO;
        }
    }
}
