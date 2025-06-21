using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarAPI.Domain.Entities
{
    public class CarRentingDetail
    {
        public int CarRentingDetailID { get; set; }
        public int CarID { get; set; }
        public Car? Car { get; set; }

        [ForeignKey("Location")]
        public int PickUpLocationID { get; set; }
        public Location? PickUpLocation { get; set; }

        [ForeignKey("Location")]
        public int DropOffLocationID { get; set; }
        public Location? DropOffLocation { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? PickUpDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? DropOffDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? PickUpTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? DropOffTime { get; set; }

        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public string? PickUpDescription { get; set; }
        public string? DropOffDescriptione { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
