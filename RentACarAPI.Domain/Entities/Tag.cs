namespace RentACarAPI.Domain.Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string? Name { get; set; }
        public int BlogID { get; set; }
        public Blog? Blog { get; set; }
    }
}
