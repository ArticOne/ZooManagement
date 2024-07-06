using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZooManagement.API.Data;
using ZooManagement.API.Model;

namespace ZooManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController(AppDbContext db) : ControllerBase
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAnimals()
        {
            var animals = await db.Animals.ToListAsync();

            return Ok(animals);
        }

        [HttpGet("[action]/{type}")]
        public async Task<IActionResult> GetAnimals(string type)
        {
            switch (type.ToLower())
            {
                case "animal":
                    return Ok(await db.Animals.OfType<Animal>().ToListAsync());
                case "carnivore":
                    return Ok(await db.Animals.OfType<CarnivoreAnimal>().ToListAsync());
                case "herbivore":
                    return Ok(await db.Animals.OfType<HerbivoreAnimal>().ToListAsync());
                case "giraffe":
                    return Ok(await db.Animals.OfType<GiraffeAnimal>().ToListAsync());
            }

            return BadRequest("Invalid animal type");
        }
    }
}
