using Microsoft.EntityFrameworkCore;
using MIS.Entity;

namespace MIS.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<StaffManager> StaffManagers { get; set; }
        public DbSet<StaffProduct> StaffProducts { get; set;}
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<StaffStatistic>StaffStatistics { get; set; }
        public DbSet<StatisticCustomer> StatisticsCustomer { get; set; }
        public DbSet<StatisticManager>StatisticManagers { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
    }
}
