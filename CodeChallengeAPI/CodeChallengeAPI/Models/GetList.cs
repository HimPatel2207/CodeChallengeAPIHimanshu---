namespace CodeChallengeAPI.Models
{
    public class GetList
    {
        public int PageNo { get; set; } = 1;
        public int Record { get; set; } = 10;
        public string SortBy { get; set; } = null;
        public string SortType { get; set; } = null;
    }
}
