namespace MIS.Entity
{
    public class Staff
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<StaffStatistic>? staffStatistics { get; set; }
        public List<StaffProduct>? staffProducts { get; set; }
    }
}
