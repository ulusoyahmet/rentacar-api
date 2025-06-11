﻿namespace RentACarAPI.Dto.CarDtos
{
    public class ResultCarWithBrandsDto
    {
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
    }
}
