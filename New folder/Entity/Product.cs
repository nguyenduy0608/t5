namespace MIS.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category {  get; set; }
        public long Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public long RemainingQuantity { get; set; }
        public long SoldQuantity { get; set; }
        public string Author { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<StaffProduct> staffProducts { get; set; }
    }
}
