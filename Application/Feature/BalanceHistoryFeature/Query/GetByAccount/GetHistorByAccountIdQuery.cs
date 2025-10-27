using Ardalis.Result;
using MediatR;

namespace Application.Feature.BalanceHistoryFeature.Query.GetByAccount
{
    public class GetHistorByAccountIdQuery : IRequest<Result<GetHistorByAccountIdResponse>>
    {
        public GetHistorByAccountIdRequest dto { get; set; }
        public GetHistorByAccountIdQuery(GetHistorByAccountIdRequest DTO)
        {
            dto = DTO;
        }
    }
}
