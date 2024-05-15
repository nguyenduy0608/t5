using Microsoft.AspNetCore.Mvc;
using MIS.Entity;
using MIS.Service;

namespace MIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;

        public WarehousesController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpGet("search")]
        public IActionResult SearchWarehouses(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return BadRequest("Search query is required.");
            }

            List<Warehouse> searchResult = _warehouseService.SearchWarehousesByName(searchQuery);

            return Ok(searchResult);
        }

        [HttpGet]
        public ActionResult<List<Warehouse>> GetAllWarehouses()
        {
            var warehouses = _warehouseService.GetAllWarehouses();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public ActionResult<Warehouse> GetWarehouseById(long id)
        {
            var warehouse = _warehouseService.GetWarehouseById(id);

            if (warehouse == null)
                return NotFound();

            return Ok(warehouse);
        }

        [HttpPost]
        public IActionResult CreateWarehouse(Warehouse warehouse)
        {
            _warehouseService.CreateWarehouse(warehouse);
            return CreatedAtAction(nameof(GetWarehouseById), new { id = warehouse.Id }, warehouse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWarehouse(long id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
                return BadRequest();

            var existingWarehouse = _warehouseService.GetWarehouseById(id);
            if (existingWarehouse == null)
                return NotFound();

            existingWarehouse.Name = warehouse.Name;
            existingWarehouse.Description = warehouse.Description;
            existingWarehouse.City = warehouse.City;
            existingWarehouse.Country = warehouse.Country;
            

            _warehouseService.UpdateWarehouse(existingWarehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWarehouse(long id)
        {
            var warehouse = _warehouseService.GetWarehouseById(id);
            if (warehouse == null)
                return NotFound();

            _warehouseService.DeleteWarehouse(warehouse);
            return NoContent();
        }
    }
}
