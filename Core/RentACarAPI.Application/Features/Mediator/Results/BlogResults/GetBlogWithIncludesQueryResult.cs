namespace RentACarAPI.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogWithIncludesQueryResult
    {
        public int BlogID { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int AuthorID { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorImageUrl{ get; set; }
        public string? AuthorDesription { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int CommentCount { get; set; }
    }
}
