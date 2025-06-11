using Newtonsoft.Json;

namespace RentACarAPI.Dto.CarPricingDto
{
    // In RentACarAPI.Dto.CarPricingDto namespace

    public class Values // Represents one car
    {
        [JsonProperty("$id")]
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

        // Property to directly hold the list of pricing details
        // This replaces 'public Carpricings carPricings { get; set; }'
        public List<Values1> PricingDetailsList { get; set; }

        public Values() // Initialize the list in the constructor
        {
            PricingDetailsList = new List<Values1>();
        }
    }

    public class Values1 // Represents each pricing detail (per hour, per day, etc.)
    {
        [JsonProperty("$id")]
        public string? id { get; set; }
        public int carPricingID { get; set; }
        public int pricingID { get; set; }
        public string? pricingName { get; set; }
        public decimal amount { get; set; }
    }

    // The Carpricings DTO would no longer be strictly needed for this specific deserialization path
    // if you adopt the manual selection below.
}
