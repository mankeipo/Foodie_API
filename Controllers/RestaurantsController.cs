using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodie.Models;

namespace Foodie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly FoodieDBContext _context;

        public RestaurantsController(FoodieDBContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        public ActionResult<IEnumerable<Restaurant>> GetRestaurants()
        {
            var restaurants = _context.Restaurants.Include(r => r.Address).ToList();

            foreach (var restaurant in restaurants)
            {
                restaurant.Address = _context.Address.Find(restaurant.LocationId);
            }

            if (restaurants == null)
            {
                var statusDescription = "No restaurants found.";
                return StatusCode(StatusCodes.Status404NotFound, new { statusCode = StatusCodes.Status404NotFound, statusDescription });
            }

            var successDescription = "Successfully retrieved restaurants.";
            return StatusCode(StatusCodes.Status200OK, new { statusCode = StatusCodes.Status200OK, statusDescription = successDescription, restaurants });
        }

        // GET: api/Restaurants/foodtype/{foodType}
        [HttpGet("foodtype/{foodType}")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurantsByFoodType(string foodType)
        {
            var restaurants = await _context.Restaurants.Include(r => r.Address)
                                                         .Where(r => r.FoodType.ToLower() == foodType.ToLower())
                                                         .ToListAsync();

            if (restaurants == null)
            {
                var statusDescription = "No restaurants found.";
                return StatusCode(StatusCodes.Status404NotFound, new { statusCode = StatusCodes.Status404NotFound, statusDescription });
            }

            var successDescription = "Successfully retrieved restaurants.";
            return StatusCode(StatusCodes.Status200OK, new { statusCode = StatusCodes.Status200OK, statusDescription = successDescription, restaurants });
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.Include(r => r.Address).FirstOrDefaultAsync(r => r.RestaurantId == id);

            if (restaurant == null)
            {
                var statusDescription = "No restaurants found.";
                return StatusCode(StatusCodes.Status404NotFound, new { statusCode = StatusCodes.Status404NotFound, statusDescription });
            }

            var successDescription = "Successfully retrieved restaurants.";
            return StatusCode(StatusCodes.Status200OK, new { statusCode = StatusCodes.Status200OK, statusDescription = successDescription, restaurant });
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.RestaurantId)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var statusDescription = "Restaurants updated.";
            return StatusCode(StatusCodes.Status200OK, new { statusCode = StatusCodes.Status200OK, statusDescription = statusDescription, restaurant });
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.RestaurantId }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();

            var statusDescription = "Restaurants deleted.";
            return StatusCode(StatusCodes.Status200OK, new { statusCode = StatusCodes.Status200OK, statusDescription = statusDescription});
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }
    }
}
