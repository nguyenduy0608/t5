namespace MIS.Entity
{
    public class Warehouse
    {
        public long Id {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<Statistic>? statistics { get; set; }
        public List<Product>? products { get; set; }
        public Shop? Shop { get; set; }
    }
}
