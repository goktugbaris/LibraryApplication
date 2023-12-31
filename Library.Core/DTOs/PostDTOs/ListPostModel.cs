namespace Library.Core.DTOs.PostDTOs
{
    public class ListPostModel
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 25;

        public string OrderField { get; set; }
        public string OrderDir { get; set; }
        public string Filter { get; set; }
    }

    public class ListPostModelById : ListPostModel
    {
        public int Id { get; set; }
    }

}
