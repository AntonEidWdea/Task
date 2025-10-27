using Ardalis.Result;
using Domain.Entities;
using Infrastrucure.Repostories;
using MediatR;

namespace Application.Feature.BalanceHistoryFeature.Query.GetByAccount
{
    public class GetHistorByAccountIdQueryHandler : IRequestHandler<GetHistorByAccountIdQuery, Result<GetHistorByAccountIdResponse>>
    {
        private readonly IGRepository<BalanceHistory> _repository;
        public GetHistorByAccountIdQueryHandler(IGRepository<BalanceHistory> repository)
        {
            _repository = repository;
        }
        public async Task<Result<GetHistorByAccountIdResponse>> Handle(GetHistorByAccountIdQuery request, CancellationToken cancellationToken)
        {
            var list = _repository.GetAllAsNoTracking(x => x.BalanceId == request.dto.Id && x.TransactionDate >= request.dto.DateFrom && x.TransactionDate <= request.dto.DateTo)
                .Select(x => new GetHistorByAccountIdDto
                {
                    AccountCode = x.Balance.AccountCode,
                    AccountName = x.Balance.AccountName,
                    AccountType = x.Balance.AccountType,
                    Credit = x.Credit,
                    Debit = x.Debit,
                    Prev_Balance = x.Prev_Balance,
                    FinalBalance = x.Balance.AccountType == "Debit" ? (x.Prev_Balance + x.Debit) - x.Credit : (x.Prev_Balance + x.Credit) - x.Debit
                })
                .ToList();

            if (!list.Any())
                return Result<GetHistorByAccountIdResponse>.NotFound();


            return Result<GetHistorByAccountIdResponse>.Success(new GetHistorByAccountIdResponse { dto = list }, "Successfully");
        }
    }
}

