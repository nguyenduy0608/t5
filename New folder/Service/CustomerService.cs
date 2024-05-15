using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class CustomerService
    {
        private readonly DataContext _dataContext;

        public CustomerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateCustomer(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            _dataContext.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return _dataContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _dataContext.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            _dataContext.Customers.Update(customer);
            _dataContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _dataContext.Customers.Remove(customer);
            _dataContext.SaveChanges();
        }
        public List<Customer> SearchCustomersByName(string searchQuery)
        {
            var result = _dataContext.Customers.Where(c => c.Name.Contains(searchQuery)).ToList();
            return result;
        }
    }
}
