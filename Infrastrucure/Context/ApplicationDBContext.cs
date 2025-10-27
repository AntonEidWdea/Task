using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastrucure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<BalanceHistory> BalanceHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BalanceHistory>()
            .HasIndex(t => t.TransactionDate)
            .HasDatabaseName("IX_Transaction_TransactionDate");

            base.OnModelCreating(modelBuilder);
        }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}
