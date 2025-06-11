using Newtonsoft.Json;

namespace RentACarAPI.Dto.CarPricingDto
{
    public class ResultCarPricingWithCarDto
    {
        [JsonProperty("$id")]
        public string? id { get; set; }
        [JsonProperty("$values")]
        public Values[]? values { get; set; }

        public class Values
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
            public Carpricings? carPricings { get; set; }
        }

        public class Carpricings
        {
            [JsonProperty("$id")]
            public string? id { get; set; }
            [JsonProperty("$values")]
            public Values1[]? values { get; set; }
        }

        public class Values1
        {
            [JsonProperty("$id")]
            public string? id { get; set; }
            public int carPricingID { get; set; }
            public int pricingID { get; set; }
            public string? pricingName { get; set; }
            public int amount { get; set; }
        }
    }

}

