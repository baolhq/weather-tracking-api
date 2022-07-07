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
    public class AccountController : ControllerBase
    {
        private readonly WeatherTrackingDbContext _context;

        public AccountController(WeatherTrackingDbContext context) => _context = context;

        public List<Account> GetAll() => _context.Accounts.ToList();
        
        public ActionResult<Account> GetById(int id)
        {
            var found = _context.Accounts.FirstOrDefault(a => a.UserId == id);
            if (found == null) return NotFound();
            return Ok(found);
        }
        
        public ActionResult<City> Add([FromBody] Account account)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Ok(account);
        }
        
        public ActionResult<City> Update([FromBody] Account account)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (found == null) return NotFound();

            _context.Accounts.Update(found);
            _context.SaveChanges();
            return Ok(found);
        }
        
        public ActionResult<City> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Model state is invalid");

            var found = _context.Accounts.FirstOrDefault(a => a.UserId == id);
            if (found == null) return NotFound();

            _context.Accounts.Remove(found);
            _context.SaveChanges();
            return Ok();
        }
    }
}