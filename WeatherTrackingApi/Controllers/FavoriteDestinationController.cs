using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherTrackingApi.Data;
using WeatherTrackingApi.Models;
using Microsoft.AspNetCore.Identity;

namespace WeatherTrackingApi.Controllers
{
    // [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteDestinationController : ControllerBase
    {
        private readonly WeatherTrackingDbContext _context;

        public FavoriteDestinationController(WeatherTrackingDbContext context) => _context = context;

        /// <summary>
        /// Get all favorite destination in database for admin management
        /// </summary>
        /// <returns>List of all favorite destination in database</returns>
        [HttpGet]
        public List<FavoriteDestination> GetAll() => _context.FavoriteDestinations.ToList();

        /// <summary>
        /// Get all favorite destination of an user in database by user id
        /// </summary>
        /// <param name="userId">ID of the user to look for</param>
        /// <returns>All favorite destination of that user</returns>
        // [Authorize(Roles = "user")]
        [HttpGet("user")]
        public List<FavoriteDestination> GetAllUserFavoriteDestinations(int userId) =>
            _context.FavoriteDestinations.Where(f => f.UserId == userId).ToList();

        /// <summary>
        /// Add new favorite destination to database with admin account
        /// </summary>
        /// <param name="destination">FavoriteDestination</param>
        /// <returns>On success response status 200 OK with added favorite destination.
        /// If model state is invalid response with status 400 Bad Request.</returns>
        [HttpPost]
        public ActionResult<FavoriteDestination> AddNew([FromBody] FavoriteDestination destination)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            _context.FavoriteDestinations.Add(destination);
            _context.SaveChanges();
            return Ok(destination);
        }

        /// <summary>
        /// Update favorite destination by user id and city id
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        [HttpPut("cityId/{cityId:int}/userId/{userId:int}")]
        public ActionResult<FavoriteDestination> Update(int cityId, int userId,
            [FromBody] FavoriteDestination destination)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context
                .FavoriteDestinations
                .FirstOrDefault(f =>
                    f.CityId == cityId
                    && f.UserId == userId);
            if (found == null) return NotFound();

            found.TimeVisit = destination.TimeVisit;
            found.AverageTravelTimeInSec = destination.AverageTravelTimeInSec;
            found.Account = destination.Account;
            found.City = destination.City;

            _context.SaveChanges();
            return Ok(found);
        }

        [HttpDelete("cityId/{cityId:int}/userId/{userId:int}")]
        public ActionResult<FavoriteDestination> Delete(int cityId, int userId)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context
                .FavoriteDestinations
                .FirstOrDefault(f =>
                    f.CityId == cityId
                    && f.UserId == userId);
            if (found == null) return NotFound();

            _context.FavoriteDestinations.Remove(found);
            _context.SaveChanges();
            return Ok();
        }
    }
}