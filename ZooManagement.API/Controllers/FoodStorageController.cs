using Microsoft.AspNetCore.Mvc;
using ZooManagement.API.Data;

namespace ZooManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodStorageController(AppDbContext db) : ControllerBase
    {
        [HttpGet("[controller]/[action]")]
        public IActionResult GetInventory()
        {
            var foodStorage = db.FoodStorage.Single();
            return Ok(foodStorage.Inventory);
        }
    }
}
