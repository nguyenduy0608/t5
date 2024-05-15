using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class ProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateProduct(Product product)
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _dataContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return _dataContext.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }
        public List<Product> SearchProductsByName(string searchQuery)
        {
            var result = _dataContext.Products.Where(p => p.Name.Contains(searchQuery)).ToList();
            return result;
        }
    }
}
