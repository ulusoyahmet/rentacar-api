namespace RentACarAPI.Dto.CarRentingDtos
{
    public class ResultCarRentingFilterDto
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public List<CarPricingDto>? CarPricings { get; set; }
    }
}
