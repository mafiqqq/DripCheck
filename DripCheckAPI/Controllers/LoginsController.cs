using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Text;
using DripCheckAPI.Models.DTO;


namespace DripCheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            return await _context.Logins.ToListAsync();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
          if (_context.Logins == null)
          {
              return NotFound();
          }
            var login = await _context.Logins.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return login;
        }

        // PUT: api/Logins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin(int id, Login login)
        {
            if (id != login.Id)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST:
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        { 
            var existingUser = await _context.Logins.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            
            if (existingUser == null  || !VerifyPassword(loginDto.PasswordHash, existingUser.PasswordHash)) 
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(existingUser);

        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            { 
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                var enteredHash = Encoding.UTF8.GetString(hashedBytes);
                return enteredHash == storedHash;
            }
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            if (_context.Logins == null)
            {
                return NotFound();
            }
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return (_context.Logins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
