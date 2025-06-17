namespace RentACarAPI.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        Task<int> GetLocationCountAsync();
        Task<int> GetAuthorCountAsync();
        Task<int> GetBlogCountAsync();
        Task<int> GetBrandCountAsync();
        Task<double> GetAvgHourlyRentingPriceAsync();
        Task<double> GetAvgDailyRentingPriceAsync();
        Task<double> GetAvgMonthlyRentingPriceAsync();
        Task<int> GetAutomaticCarCountAsync();
        Task<string> GetBrandNameWithMostCarsAsync();
        Task<string> GetBlogTitleWithMostCommentsAsync();
        Task<int> GetCarCountUnder1000KmAsync();
        Task<int> GetDieselOrGasolineCarCountAsync();
        Task<int> GetElectricCarCountAsync();
        Task<string> GetMostExpensiveCarNameAsync();
        Task<string> GetMostAffordableCarNameAsync();
    }
}
