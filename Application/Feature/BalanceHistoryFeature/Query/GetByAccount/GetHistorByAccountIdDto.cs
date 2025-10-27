namespace Application.Feature.BalanceHistoryFeature.Query.GetByAccount
{
    public class GetHistorByAccountIdDto
    {
        public required string AccountCode { get; set; }
        public required string AccountName { get; set; }
        public required string AccountType { get; set; }
        public decimal Prev_Balance { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal FinalBalance { get; set; }

    }
}
