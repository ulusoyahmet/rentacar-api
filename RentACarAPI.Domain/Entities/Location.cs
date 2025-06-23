namespace RentACarAPI.Domain.Entities
{
    public class Location
    {
        public int LocationID { get; set; }
        public string? Name { get; set; }
        public List<CarRenting>? CarRentings { get; set; }
        public List<CarBooking>? PickUpCarBookings { get; set; }
        public List<CarBooking>? DropOffCarBookings { get; set; }
    }
}
