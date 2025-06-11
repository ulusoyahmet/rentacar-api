using System.Collections.Generic;

namespace RentACarAPI.Dto.CarPricingDto
{
    // Represents each pricing detail (per hour, per day, etc.)
    // This was previously named Values1.
    public class CarPricingDto
    {
        public int CarPricingID { get; set; }
        public int PricingID { get; set; }
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }

    // Represents one car object from the API response
    // This was previously named Values.
    public class CarWithPricingDto
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public int Seat { get; set; }
        public int Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }

        // This property directly maps to the "carPricings" array in the JSON.
        public List<CarPricingDto> CarPricings { get; set; }

        public CarWithPricingDto() // Good practice to initialize lists
        {
            CarPricings = new List<CarPricingDto>();
        }
    }
}