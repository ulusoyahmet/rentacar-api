using System.ComponentModel.DataAnnotations.Schema;

namespace RentACarAPI.Domain.Entities
{
    public class CarBooking
    {
        public int CarBookingID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int CarID { get; set; }
        public Car? Car { get; set; }

        [ForeignKey("Location")]
        public int PickUpLocationID { get; set; }
        public Location? PickUpLocation { get; set; }

        [ForeignKey("Location")]
        public int DropOffLocationID { get; set; }
        public Location? DropOffLocation { get; set; }

        public int Age { get; set; }
        public int LicenseYear { get; set; }
        public string Message { get; set; }
        public string? Status { get; set; }

    }
}
