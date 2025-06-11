namespace RentACarAPI.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByIdQueryResult
    {
        public int BlogID { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int AuthorID { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CategoryID { get; set; }
    }
}
