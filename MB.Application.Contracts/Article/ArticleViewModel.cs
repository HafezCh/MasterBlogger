namespace MB.Application.Contracts.Article
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
        public string ArticleCategory { get; set; }
        public string CreationDate { get; set; }
    }
}
