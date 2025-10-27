using Ardalis.Result;
using MediatR;

namespace Application.Feature.BalanceFeature.Query.GetAll
{
    public class GetAllBalanceQuery : IRequest<Result<GetAllBalanceResponse>>
    {

        public GetAllBalanceQuery()
        {
        }
    }
}
