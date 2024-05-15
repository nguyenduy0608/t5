namespace MIS.Entity
{
    public class Manager
    {
        public long id {  get; set; }
        public string? name { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Gender { get; set; }
        public List<StatisticManager>? statisticManagers { get; set; }
    }
}
