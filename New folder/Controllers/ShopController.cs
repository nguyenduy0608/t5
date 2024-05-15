using Microsoft.AspNetCore.Mvc;
using MIS.Entity;
using MIS.Service;

namespace MIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopsController(ShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet("search")]
        public IActionResult SearchShops(string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                return BadRequest("Search query is required.");
            }

            List<Shop> searchResult = _shopService.SearchShopsByName(searchQuery);

            return Ok(searchResult);
        }

        [HttpGet]
        public ActionResult<List<Shop>> GetAllShops()
        {
            var shops = _shopService.GetAllShops();
            return Ok(shops);
        }

        [HttpGet("{id}")]
        public ActionResult<Shop> GetShopById(int id)
        {
            var shop = _shopService.GetShopById(id);

            if (shop == null)
                return NotFound();

            return Ok(shop);
        }

        [HttpPost]
        public IActionResult CreateShop(Shop shop)
        {
            _shopService.CreateShop(shop);
            return CreatedAtAction(nameof(GetShopById), new { id = shop.Id }, shop);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShop(int id, Shop shop)
        {
            if (id != shop.Id)
                return BadRequest();

            var existingShop = _shopService.GetShopById(id);
            if (existingShop == null)
                return NotFound();

            existingShop.Name = shop.Name;
            existingShop.Address = shop.Address;
            existingShop.Phone = shop.Phone;

            _shopService.UpdateShop(existingShop);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShop(int id)
        {
            var shop = _shopService.GetShopById(id);
            if (shop == null)
                return NotFound();

            _shopService.DeleteShop(shop);
            return NoContent();
        }
    }
}
