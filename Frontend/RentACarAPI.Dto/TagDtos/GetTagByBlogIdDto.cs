namespace RentACarAPI.Dto.TagDtos
{
    public class GetTagByBlogIdDto
    {
        public int TagID { get; set; }
        public string? Name { get; set; }
        public int BlogID { get; set; }
    }
}
