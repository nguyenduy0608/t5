using Microsoft.AspNetCore.Mvc;
using MIS.Entity;
using MIS.Service;

namespace MIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly StatisticService _statisticService;

        public StatisticsController(StatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("search")]
        public IActionResult SearchStatistics(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return BadRequest("Search query is required.");
            }

            List<Statistic> searchResult = _statisticService.SearchStatisticsByName(searchQuery);

            return Ok(searchResult);
        }
        [HttpGet]
        public ActionResult<List<Statistic>> GetAllStatistics()
        {
            var statistics = _statisticService.GetAllStatistics();
            return Ok(statistics);
        }

        [HttpGet("{id}")]
        public ActionResult<Statistic> GetStatisticById(int id)
        {
            var statistic = _statisticService.GetStatisticById(id);

            if (statistic == null)
                return NotFound();

            return Ok(statistic);
        }

        [HttpPost]
        public IActionResult CreateStatistic(Statistic statistic)
        {
            _statisticService.CreateStatistic(statistic);
            return CreatedAtAction(nameof(GetStatisticById), new { id = statistic.Id }, statistic);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStatistic(int id, Statistic statistic)
        {
            if (id != statistic.Id)
                return BadRequest();

            var existingStatistic = _statisticService.GetStatisticById(id);
            if (existingStatistic == null)
                return NotFound();

            existingStatistic.Name = statistic.Name;
            existingStatistic.Description = statistic.Description;
            existingStatistic.Type = statistic.Type;

            _statisticService.UpdateStatistic(existingStatistic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStatistic(int id)
        {
            var statistic = _statisticService.GetStatisticById(id);
            if (statistic == null)
                return NotFound();

            _statisticService.DeleteStatistic(statistic);
            return NoContent();
        }
    }
}
