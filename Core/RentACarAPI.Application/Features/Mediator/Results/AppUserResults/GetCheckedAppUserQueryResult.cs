namespace RentACarAPI.Application.Features.Mediator.Results.AppUserResults
{
    public class GetCheckedAppUserQueryResult
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExists { get; set; }
    }
}