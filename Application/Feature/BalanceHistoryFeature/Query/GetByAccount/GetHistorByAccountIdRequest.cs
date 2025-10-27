namespace Application.Feature.BalanceHistoryFeature.Query.GetByAccount
{
    public class GetHistorByAccountIdRequest
    {
        public required int Id { get; set; }
        public required DateTime DateFrom { get; set; }
        public required DateTime DateTo { get; set; }

    }
}
