namespace Infrastrucure.Helpers
{
    public class ResponsePagination
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
    }
}
