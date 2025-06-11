namespace RentACarAPI.Application.Features.Mediator.Results.CarPricingResults
{
    public class CarPricingDto
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public string? PricingName { get; set; } // e.g., Daily, Weekly, Monthly
        public decimal Amount { get; set; }
    }
}
