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
    public class AccountController : ControllerBase
    {
        private readonly WeatherTrackingDbContext _context;

        public AccountController(WeatherTrackingDbContext context) => _context = context;

        [HttpGet]
        public List<Account> GetAll() => _context.Accounts.ToList();

        [HttpGet("{id:int}")]
        public ActionResult<Account> GetById(int id)
        {
            var found = _context.Accounts.FirstOrDefault(a => a.UserId == id);
            if (found == null) return NotFound();
            return Ok(found);
        }

        [HttpPost]
        public ActionResult<City> Add([FromBody] Account account)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            // Hash password
            account.Password = Utils.ComputeSha256Hash(account.Password);

            // Check for username conflict
            if (IsUsernameExist(account.Username)) return BadRequest();

            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Ok(account);
        }

        [HttpPut("{id:int}")]
        public ActionResult<City> Update(int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Accounts.FirstOrDefault(a => a.UserId == id);
            if (found == null) return NotFound();

            // Hash password
            found.Password = Utils.ComputeSha256Hash(account.Password);

            // Check for username conflict
            if (IsUsernameExist(account.Username)) return BadRequest();

            found.Username = account.Username;
            found.FullName = account.FullName;
            found.Email = account.Email;
            found.IsEmailValidated = account.IsEmailValidated;
            found.Address = account.Address;
            found.DateOfBirth = account.DateOfBirth;
            found.LastLogin = account.LastLogin;
            found.IsActive = account.IsActive;
            found.IsAdmin = account.IsAdmin;
            found.TransportHistory = account.TransportHistory;
            found.BookingSchedule = account.BookingSchedule;
            found.FavoriteDestination = account.FavoriteDestination;

            _context.SaveChanges();
            return Ok(found);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<City> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Accounts.FirstOrDefault(a => a.UserId == id);
            if (found == null) return NotFound();

            _context.Accounts.Remove(found);
            _context.SaveChanges();
            return Ok();
        }

        public bool IsUsernameExist(string username) => _context.Accounts.Any(a => a.Username == username);
    }
}