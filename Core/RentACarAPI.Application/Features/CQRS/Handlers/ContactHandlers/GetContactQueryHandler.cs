using RentACarAPI.Application.Features.CQRS.Results.ContactResults;
using RentACarAPI.Application.Interfaces;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult()
            {
                ContactID = x.ContactID,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                SentDate = x.SentDate,
                Subject = x.Subject
            }).ToList();
        }
    }
}
