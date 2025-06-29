namespace RentACarAPI.Dto.CarDtos
{
    public class CarPricingDto
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public decimal Amount { get; set; }
        public string? PricingName { get; set; }
    }
}
