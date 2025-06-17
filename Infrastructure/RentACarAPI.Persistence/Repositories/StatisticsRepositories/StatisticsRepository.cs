using Microsoft.EntityFrameworkCore;
using RentACarAPI.Application.Interfaces.StatisticsInterfaces;
using RentACarAPI.Persistence.Context;

namespace RentACarAPI.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository: IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<int> GetAutomaticCarCountAsync()
        {
            return await _context.Cars.CountAsync(c => c.Transmission == "Automatic");
        }

        public async Task<int> GetBlogCountAsync()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<string> GetBlogTitleWithMostCommentsAsync()
        {
            var blog = await _context.Blogs
                .Include(x => x.Comments)
                .OrderByDescending(b => b.Comments.Count)
                .Select(b => b.Title)
                .FirstOrDefaultAsync();
            return blog ?? string.Empty;
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetBrandNameWithMostCarsAsync()
        {
            var brand = await _context.Cars
                .Include(x => x.Brand)
                .GroupBy(c => c.Brand.Name)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefaultAsync();
            return brand ?? string.Empty;
        }

        public async Task<int> GetCarCountUnder1000KmAsync()
        {
            return await _context.Cars.CountAsync(c => c.Km < 1000);
        }

        public async Task<double> GetAvgDailyRentingPriceAsync()
        {
            // Get the PricingID for "per day"
            var daylyPricingId = await _context.Pricings
                .Where(x => x.Name == "per day")
                .Select(x => x.PricingID)
                .FirstOrDefaultAsync();

            // If not found, return 0
            if (daylyPricingId == 0)
                return 0;

            // Get all CarPricings with that PricingID and average the Amount
            return await _context.CarPricings
                .Where(cp => cp.PricingID == daylyPricingId)
                .AverageAsync(cp => (double)cp.Amount);
        }

        public async Task<int> GetDieselOrGasolineCarCountAsync()
        {
            return await _context.Cars.CountAsync(c => c.Fuel == "Diesel" || c.Fuel == "Petrol");
        }

        public async Task<int> GetElectricCarCountAsync()
        {
            return await _context.Cars.CountAsync(c => c.Fuel == "Electric");
        }

        public async Task<double> GetAvgHourlyRentingPriceAsync()
        {
            // Get the PricingID for "per hour"
            var hourlyPricingId = await _context.Pricings
                .Where(x => x.Name == "per hour")
                .Select(x => x.PricingID)
                .FirstOrDefaultAsync();

            // If not found, return 0
            if (hourlyPricingId == 0)
                return 0;

            // Get all CarPricings with that PricingID and average the Amount
            return await _context.CarPricings
                .Where(cp => cp.PricingID == hourlyPricingId)
                .AverageAsync(cp => (double)cp.Amount);
        }

        public async Task<int> GetLocationCountAsync()
        {
            return await _context.Locations.CountAsync();
        }

        public async Task<string> GetMostAffordableCarNameAsync()
        {
            // Get the PricingID for "per day"
            var dailyPricingId = await _context.Pricings
                .Where(x => x.Name == "per day")
                .Select(x => x.PricingID)
                .FirstOrDefaultAsync();

            if (dailyPricingId == 0)
                return string.Empty;

            // Find the car with the highest price under "per day" pricing
            var mostExpensiveCarName = await _context.CarPricings
                .Include(x => x.Car)
                .Where(cp => cp.PricingID == dailyPricingId)
                .OrderBy(cp => cp.Amount)
                .Select(cp => cp.Car.Model)
                .FirstOrDefaultAsync();

            return mostExpensiveCarName ?? string.Empty;
        }

        public async Task<string> GetMostExpensiveCarNameAsync()
        {
            // Get the PricingID for "per day"
            var dailyPricingId = await _context.Pricings
                .Where(x => x.Name == "per day")
                .Select(x => x.PricingID)
                .FirstOrDefaultAsync();

            if (dailyPricingId == 0)
                return string.Empty;

            // Find the car with the highest price under "per day" pricing
            var mostExpensiveCarName = await _context.CarPricings
                .Where(cp => cp.PricingID == dailyPricingId)
                .OrderByDescending(cp => cp.Amount)
                .Select(cp => cp.Car.Model)
                .FirstOrDefaultAsync();

            return mostExpensiveCarName ?? string.Empty;
        }

        public async Task<double> GetAvgMonthlyRentingPriceAsync()
        {
            // Get the PricingID for "per month"
            var monthlyPricingId = await _context.Pricings
                .Where(x => x.Name == "per month")
                .Select(x => x.PricingID)
                .FirstOrDefaultAsync();

            // If not found, return 0
            if (monthlyPricingId == 0)
                return 0;

            // Get all CarPricings with that PricingID and average the Amount
            return await _context.CarPricings
                .Where(cp => cp.PricingID == monthlyPricingId)
                .AverageAsync(cp => (double)cp.Amount);
        }
    }
}
