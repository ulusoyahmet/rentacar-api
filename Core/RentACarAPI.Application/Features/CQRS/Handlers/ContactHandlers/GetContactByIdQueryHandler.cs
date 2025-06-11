using RentACarAPI.Application.Features.CQRS.Queries.ContactQueries;
using RentACarAPI.Application.Features.CQRS.Results.ContactResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetContactQueryResult()
            {
                ContactID = value.ContactID,
                Email = value.Email,
                Message = value.Message,
                Name = value.Name,
                SentDate = value.SentDate,
                Subject = value.Subject
            };
        }
    }
}
