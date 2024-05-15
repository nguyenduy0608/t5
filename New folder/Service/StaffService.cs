using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class StaffService
    {
        private readonly DataContext _dataContext;

        public StaffService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CreateStaff(Staff staff)
        {
            _dataContext.Staffs.Add(staff);
            _dataContext.SaveChanges();
        }

        public Staff GetStaffById(int id)
        {
            return _dataContext.Staffs.FirstOrDefault(s => s.Id == id);
        }

        public List<Staff> GetAllStaffs()
        {
            return _dataContext.Staffs.ToList();
        }

        public void UpdateStaff(Staff staff)
        {
            _dataContext.Staffs.Update(staff);
            _dataContext.SaveChanges();
        }

        public void DeleteStaff(Staff staff)
        {
            _dataContext.Staffs.Remove(staff);
            _dataContext.SaveChanges();
        }
    }
}
