using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Balance
    {
        [Key]
        public int Id { get; set; }
        public required string AccountCode { get; set; }
        public required string AccountName { get; set; }
        public required string AccountType { get; set; }
        public virtual ICollection<BalanceHistory> BalanceHistories { get; set; } = new HashSet<BalanceHistory>();
    }
}
