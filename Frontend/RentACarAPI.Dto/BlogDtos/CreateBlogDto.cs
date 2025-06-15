namespace RentACarAPI.Dto.BlogDtos
{
    public class CreateBlogDto
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int AuthorID { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int CategoryID { get; set; }
    }
}
