using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class ManagerService
    {
        private readonly DataContext _dataContext;

        public ManagerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateManager(Manager manager)
        {
            _dataContext.Managers.Add(manager);
            _dataContext.SaveChanges();
        }

        public Manager GetManagerById(long id)
        {
            return _dataContext.Managers.FirstOrDefault(m => m.id == id);
        }

        public List<Manager> GetAllManagers()
        {
            return _dataContext.Managers.ToList();
        }

        public void UpdateManager(Manager manager)
        {
            _dataContext.Managers.Update(manager);
            _dataContext.SaveChanges();
        }

        public void DeleteManager(Manager manager)
        {
            _dataContext.Managers.Remove(manager);
            _dataContext.SaveChanges();
        }
    }
}
