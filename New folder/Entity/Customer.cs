namespace MIS.Entity
{
    public class Customer
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public bool ? Status { get; set; }=true;
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public List<StatisticCustomer>? statisticCustomers { get; set; }
    }
}
