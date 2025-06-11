﻿namespace RentACarAPI.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public Car? Car { get; set; }
        public string? Detail { get; set; }
    }
}
