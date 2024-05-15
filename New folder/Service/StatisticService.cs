using MIS.Context;
using MIS.Entity;

namespace MIS.Service
{
    public class StatisticService
    {
        private readonly DataContext _dataContext;

        public StatisticService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Statistic> SearchStatisticsByName(string searchQuery)
        {
            var result = _dataContext.Statistics.Where(s => s.Name.Contains(searchQuery)).ToList();
            return result;
        }
        public void CreateStatistic(Statistic statistic)
        {
            _dataContext.Statistics.Add(statistic);
            _dataContext.SaveChanges();
        }

        public Statistic GetStatisticById(int id)
        {
            return _dataContext.Statistics.FirstOrDefault(s => s.Id == id);
        }

        public List<Statistic> GetAllStatistics()
        {
            return _dataContext.Statistics.ToList();
        }

        public void UpdateStatistic(Statistic statistic)
        {
            _dataContext.Statistics.Update(statistic);
            _dataContext.SaveChanges();
        }

        public void DeleteStatistic(Statistic statistic)
        {
            _dataContext.Statistics.Remove(statistic);
            _dataContext.SaveChanges();
        }
    }
}
