using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarAPI.Domain.Entities
{
    public class CarRenting
    {
        public int CarRentingID { get; set; }
        [ForeignKey("Location")]
        public int PickUpLocationID { get; set; }
        public Location? PickUpLocation { get; set; }
        public int CarID { get; set; }
        public Car? Car { get; set; }
        public bool Available { get; set; }

    }
}
