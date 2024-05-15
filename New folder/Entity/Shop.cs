namespace MIS.Entity
{
    public class Shop
    {
        public long Id {  get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public List<Warehouse>? warehouses { get; set; }
    }
}
