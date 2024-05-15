using Microsoft.EntityFrameworkCore;
using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class WarehouseService
    {
        private readonly DataContext _dbContext;

        public WarehouseService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Warehouse> SearchWarehousesByName(string searchQuery)
        {
            var result = _dbContext.Warehouse.Where(w => w.Name.Contains(searchQuery)).ToList();
            return result;
        }
        public List<Warehouse> GetAllWarehouses()
        {
            return _dbContext.Warehouse.ToList();
        }

        public Warehouse GetWarehouseById(long id)
        {
            return _dbContext.Warehouse.FirstOrDefault(w => w.Id == id);
        }

        public void CreateWarehouse(Warehouse warehouse)
        {
            _dbContext.Warehouse.Add(warehouse);
            _dbContext.SaveChanges();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            _dbContext.Warehouse.Update(warehouse);
            _dbContext.SaveChanges();
        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            _dbContext.Warehouse.Remove(warehouse);
            _dbContext.SaveChanges();
        }
    }
}
