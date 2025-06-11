namespace RentACarAPI.Application.Features.Mediator.Results.TagResults
{
    public class GetTagByBlogIdQueryResult
    {
        public int TagID { get; set; }
        public string? Name { get; set; }
        public int BlogID { get; set; }
    }
}
