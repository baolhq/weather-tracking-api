using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherTrackingApi.Data;
using WeatherTrackingApi.Models;

namespace WeatherTrackingApi.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly WeatherTrackingDbContext _context;

        public CityController(WeatherTrackingDbContext context) => _context = context;

        [AllowAnonymous]
        public List<City> GetAll() => _context.Cities.ToList();

        [AllowAnonymous]
        public ActionResult<City> GetById(int id)
        {
            var found = _context.Cities.FirstOrDefault(c => c.CityId == id);
            if (found == null) return NotFound();
            return Ok(found);
        }

        public ActionResult<City> Add([FromBody] City city)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            _context.Cities.Add(city);
            _context.SaveChanges();
            return Ok(city);
        }

        public ActionResult<City> Update([FromBody] City city)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Cities.FirstOrDefault(c => c.CityId == city.CityId);
            if (found == null) return NotFound();

            _context.Cities.Update(found);
            _context.SaveChanges();
            return Ok(found);
        }

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