using Ardalis.Result;
using Domain.Entities;
using Infrastrucure.Repostories;
using MediatR;

namespace Application.Feature.BalanceFeature.Query.GetAll
{
    public class GetAllBalanceQueryHandler : IRequestHandler<GetAllBalanceQuery, Result<GetAllBalanceResponse>>
    {
        private readonly IGRepository<Balance> _repository;
        public GetAllBalanceQueryHandler(IGRepository<Balance> repository)
        {
            _repository = repository;
        }
        public async Task<Result<GetAllBalanceResponse>> Handle(GetAllBalanceQuery request, CancellationToken cancellationToken)
        {
            var list = _repository.GetAllNoTracking()
                .Select(x => new GetAllBalanceResponsedto
                {
                    Id = x.Id,
                    AccountCode = x.AccountCode,
                    AccountName = x.AccountName
                })
                .ToList();

            if (!list.Any())
                return Result<GetAllBalanceResponse>.NotFound();


            return Result<GetAllBalanceResponse>.Success(new GetAllBalanceResponse { dto = list }, "Successfully");
        }
    }
}

