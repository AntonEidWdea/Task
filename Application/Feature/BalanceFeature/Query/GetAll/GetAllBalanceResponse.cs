namespace Application.Feature.BalanceFeature.Query.GetAll
{
    public class GetAllBalanceResponse
    {
        public List<GetAllBalanceResponsedto> dto { get; set; }
    }
    public class GetAllBalanceResponsedto
    {
        public int Id { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
    }
}
