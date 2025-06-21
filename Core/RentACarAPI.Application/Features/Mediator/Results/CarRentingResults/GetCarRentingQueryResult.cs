using RentACarAPI.Application.Features.Mediator.Results.CarPricingResults;

namespace RentACarAPI.Application.Features.Mediator.Results.CarRentingResults
{
    public class GetCarRentingQueryResult
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public List<CarPricingDto>? CarPricings { get; set; }
    }
}
