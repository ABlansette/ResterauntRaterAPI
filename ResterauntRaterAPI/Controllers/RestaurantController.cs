using ResterauntRaterAPI.Areas.HelpPage.Models;
using ResterauntRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ResterauntRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    { 
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        // CRUD = PGPD 
        //Create = POST
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if(model == null)
            {
                return BadRequest("Your request cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Restaurant.Add(model);
                await _context.SaveChangesAsync();

                return Ok("You created a restraunt with a rating and it was saved");
            }
            return BadRequest(ModelState);

        }


        //READ = GET
        [HttpGet]
        public async Task<IHttpActionResult> GetByID(int id)
        {
            Restaurant restaurant = await _context.Restaurant.FindAsync(id);
            return Ok();
        }
        // GetALL
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaunts = await _context.Restaurant.ToListAsync();
            return Ok(restaunts);
        }

        //Update = PUT
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri]int id, [FromBody]Restaurant updatedRestaurant)
        {
            if(ModelState.IsValid)
            {

                Restaurant restaurant = await _context.Restaurant.FindAsync(id);

                if(restaurant != null)
                {
                    //Update the restaurant now that we found it
                    restaurant.Name = updatedRestaurant.Name;
                    restaurant.Rating = updatedRestaurant.Rating;

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                // Didnt find the restaurant
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        //DELETE = DELETE



    }
}
