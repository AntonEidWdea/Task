using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BalanceHistory
    {
        [Key]
        public int Id { get; set; }
        public int BalanceId { get; set; }
        public virtual Balance Balance { get; set; }
        public required DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Prev_Balance { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
