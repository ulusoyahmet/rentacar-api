using MediatR;
using RentACarAPI.Application.Features.Mediator.Queries.CarDescriptionQueries;
using RentACarAPI.Application.Features.Mediator.Results.CarDescriptionResults;
using RentACarAPI.Application.Interfaces.CarDescriptionInterfaces;

namespace RentACarAPI.Application.CarDescriptions.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByIdQueryHandler:
        IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;
        public GetCarDescriptionByIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarDescriptionByCarId(request.Id);
            return new GetCarDescriptionByCarIdQueryResult()
            {
                CarDescriptionID = value.CarDescriptionID,
                CarID = request.Id,
                Detail = value.Detail
            };
        }
    }
}
