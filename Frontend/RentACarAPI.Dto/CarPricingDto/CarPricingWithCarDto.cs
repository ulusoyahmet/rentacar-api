namespace RentACarAPI.Dto.CarPricingDto
{
    public class CarPricingWithCarDto
    {
        public string? id { get; set; }
        public int carID { get; set; }
        public int brandID { get; set; }
        public string? brandName { get; set; }
        public string? model { get; set; }
        public string? coverImageUrl { get; set; }
        public int km { get; set; }
        public string? transmission { get; set; }
        public int seat { get; set; }
        public int luggage { get; set; }
        public string? fuel { get; set; }
        public string? bigImageUrl { get; set; }
        public CarPricings? carPricings { get; set; }
    }

    public class CarPricings
    {
        public string? id { get; set; }
        public PricingValues[]? values { get; set; }
    }

    public class PricingValues
    {
        public string? id { get; set; }
        public int carPricingID { get; set; }
        public int pricingID { get; set; }
        public string? pricingName { get; set; }
        public int amount { get; set; }
    }
}
