namespace RentACarAPI.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<CarRentingDetail>? CarRentingDetails { get; set; }
    }
}
