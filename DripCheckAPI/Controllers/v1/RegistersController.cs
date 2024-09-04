using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;
using System.Text;
using System.Security.Cryptography;

namespace DripCheckAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Login>> PostRegister(Login login)
        {
            if (_context.Logins == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Logins'  is null.");
            }

            login.PasswordHash = HashPassword(login.PasswordHash);
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Encoding.UTF8.GetString(hashedBytes);
            }
        }

        private bool LoginExists(int id)
        {
            return (_context.Logins?.Any(e => e.LoginId == id)).GetValueOrDefault();
        }
    }
}