using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetCarReviewsByCarId(int id);
    }
}
