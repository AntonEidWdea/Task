using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrucure.Context
{
    public class ContextSeed
    {
        private static ApplicationDBContext _dbContext;
        private static IServiceProvider _serviceProvider;
        public static void Seed(ApplicationDBContext appDbContext, IServiceProvider serviceProvider)
        {
            _dbContext = appDbContext;
            _dbContext.Database.EnsureCreated();
            _serviceProvider = serviceProvider;
            SeedDataBalance();
        }
        private static void SeedDataBalance()
        {
            if (!_dbContext.Balances.Any())
            {
                var obj = new Balance
                {
                    AccountCode = "11038",
                    AccountName = "Clients Class A",
                    AccountType = "Debit",
                    BalanceHistories = new List<BalanceHistory>() { new BalanceHistory { Credit = 0, TransactionDate = DateTime.Now, Debit = 100, Description = "test", Prev_Balance = 50 } }
                };
                using (var scope = _serviceProvider.CreateScope())
                {
                    try
                    {
                        if (!_dbContext.Balances.Any())
                        {
                            _dbContext.Balances.AddRange(obj);
                            _dbContext.SaveChanges();
                        }
                    }
                    catch { }
                }
            }
        }

    }
}
