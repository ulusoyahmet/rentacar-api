namespace RentACarAPI.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionByCarIdQueryResult
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string? Detail { get; set; }
    }
}
