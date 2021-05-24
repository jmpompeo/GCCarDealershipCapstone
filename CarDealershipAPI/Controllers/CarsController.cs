using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarDealershipAPI.Data;
using CarDealershipAPI.Models;

namespace CarDealershipAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetCar()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCars(int id)
        {
            var cars = await _context.Cars.FindAsync(id);

            if (cars == null)
            {
                return NotFound();
            }

            return cars;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Cars>>> Search(string query)
        {

            var cars = await _context.Cars.Where(x => x.Make == query || x.Color == query || x.Model == query).ToListAsync();

            if (cars == null)
            {
                return NotFound();
            }

            return cars;
        }

        [HttpGet("year")]
        public async Task<ActionResult<IEnumerable<Cars>>> SearchYear(int year)
        {

            var cars = await _context.Cars.Where(x => x.Year == year).ToListAsync();

            if (cars == null)
            {
                return NotFound();
            }

            return cars;
        }
    }
}
