namespace RentACarAPI.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public int LocationCount { get; set; }
        public string? BrandName { get; set; }
        public string? BlogTitle { get; set; }
        public int AutomaricCarCount { get; set; }
        public int CarCountUnder1000Km { get; set; }
        public double AvgHourlyPrice { get; set; }
        public double AvgDailyPrice { get; set; }
        public double AvgMonthlyPrice { get; set; }
        public int ElectricCarCount { get; set; }
        public int IntCombCarCount { get; set; }
        public string? MostAffordableCarName { get; set; }
        public string? MostExpensiveCarName { get; set; }

    }
}
