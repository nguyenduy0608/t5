using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class ShopService
    {
        private readonly DataContext _dataContext;

        public ShopService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateShop(Shop shop)
        {
            _dataContext.Shops.Add(shop);
            _dataContext.SaveChanges();
        }

        public Shop GetShopById(int id)
        {
            return _dataContext.Shops.FirstOrDefault(s => s.Id == id);
        }

        public List<Shop> GetAllShops()
        {
            return _dataContext.Shops.ToList();
        }

        public void UpdateShop(Shop shop)
        {
            _dataContext.Shops.Update(shop);
            _dataContext.SaveChanges();
        }

        public void DeleteShop(Shop shop)
        {
            _dataContext.Shops.Remove(shop);
            _dataContext.SaveChanges();
        }
        public List<Shop> SearchShopsByName(string searchQuery)
        {
            var result = _dataContext.Shops.Where(s => s.Name.Contains(searchQuery)).ToList();
            return result;
        }
    }
}
