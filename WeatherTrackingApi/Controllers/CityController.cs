using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherTrackingApi.Data;
using WeatherTrackingApi.Models;

namespace WeatherTrackingApi.Controllers
{
    // [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly WeatherTrackingDbContext _context;

        public CityController(WeatherTrackingDbContext context) => _context = context;

        // [AllowAnonymous]
        [HttpGet]
        public List<City> GetAll() => _context.Cities.ToList();

        // [AllowAnonymous]
        [HttpGet("{id:int}")]
        public ActionResult<City> GetById(int id)
        {
            var found = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (found == null) return NotFound();
            return Ok(found);
        }

        [HttpPost]
        public ActionResult<City> Add([FromBody] City city)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            _context.Cities.Add(city);
            _context.SaveChanges();
            return Ok(city);
        }

        [HttpPut("{id:int}")]
        public ActionResult<City> Update(int id, [FromBody] City city)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (found == null) return NotFound();

            found.CityName = city.CityName;
            found.TimeZone = city.TimeZone;
            found.Longitude = city.Longitude;
            found.Latitude = city.Latitude;
            found.BookingSchedule = city.BookingSchedule;
            found.SuggestBoard = city.SuggestBoard;
            found.WeatherStatus = city.WeatherStatus;
            found.FavoriteDestination = city.FavoriteDestination;

            _context.SaveChanges();
            return Ok(found);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<City> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (found == null) return NotFound();

            _context.Cities.Remove(found);
            _context.SaveChanges();
            return Ok();
        }
    }
}