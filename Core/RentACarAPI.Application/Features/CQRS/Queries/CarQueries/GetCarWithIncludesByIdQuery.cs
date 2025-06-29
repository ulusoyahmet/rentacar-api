namespace RentACarAPI.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithIncludesByIdQuery
    {
        public int Id { get; set; }

        public GetCarWithIncludesByIdQuery(int id)
        {
            Id = id;
        }
    }
}
