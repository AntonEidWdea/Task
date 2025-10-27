using Ardalis.Result;
using Domain.Entities;
using Infrastrucure.Repostories;
using MediatR;

namespace Application.Feature.BalanceFeature.Command.Post
{
    public class PostBalanceCommandHandler : IRequestHandler<PostBalanceCommand, Result<PostBalanceResponse>>
    {
        private readonly IGRepository<Balance> _repository;
        public PostBalanceCommandHandler(IGRepository<Balance> repository)
        {
            _repository = repository;
        }
        public async Task<Result<PostBalanceResponse>> Handle(PostBalanceCommand request, CancellationToken cancellationToken)
        {
            var obj = new Balance
            {
                AccountCode = request.dto.AccountCode,
                AccountName = request.dto.AccountName,
                AccountType = request.dto.AccountType,
            };

            await _repository.AddAsync(obj);
            await _repository.SaveChangesAsync();
            return Result<PostBalanceResponse>.Success(new PostBalanceResponse()
            {
                Id = obj.Id
            }, "AddedSuccessfully");
        }
    }
}
