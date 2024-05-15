namespace MIS.Entity
{
    public class Statistic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public List<StatisticCustomer>? statisticCustomers { get; set; }
        public List<StaffStatistic>? staffStatistics { get; set;}
        public List<StatisticManager>? statisticManagers { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
