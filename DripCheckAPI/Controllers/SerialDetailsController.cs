using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;

namespace DripCheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerialDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SerialDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SerialDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SerialDetail>>> GetSerialDetails()
        {
          if (_context.SerialDetails == null)
          {
              return NotFound();
          }
            return await _context.SerialDetails.ToListAsync();
        }

        // GET: api/SerialDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SerialDetail>> GetSerialDetail(int id)
        {
          if (_context.SerialDetails == null)
          {
              return NotFound();
          }
            var serialDetail = await _context.SerialDetails.FindAsync(id);

            if (serialDetail == null)
            {
                return NotFound();
            }

            return serialDetail;
        }

        // GET: api/SerialDetails/SerialNumber
        [HttpGet("SerialNumber/{serialNumber}")]
        public async Task<ActionResult<SerialDetail>> GetSerialDetailBySerialNumber(string serialNumber)
        {
            if (_context.SerialDetails == null)
            {
                return NotFound();
            }

            var serialDetail = await _context.SerialDetails.FirstOrDefaultAsync(s => s.SerialNumber == serialNumber);

            if (serialDetail == null)
            {
                return NotFound();
            }

            return serialDetail;

        }

        // PUT: api/SerialDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerialDetail(int id, SerialDetail serialDetail)
        {
            if (id != serialDetail.SerialDetailId)
            {
                return BadRequest();
            }

            _context.Entry(serialDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialDetailExists(id))
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

        // POST: api/SerialDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SerialDetail>> PostSerialDetail(SerialDetail serialDetail)
        {
          if (_context.SerialDetails == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SerialDetails'  is null.");
          }
            _context.SerialDetails.Add(serialDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerialDetail", new { id = serialDetail.SerialDetailId }, serialDetail);
        }

        // DELETE: api/SerialDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerialDetail(int id)
        {
            if (_context.SerialDetails == null)
            {
                return NotFound();
            }
            var serialDetail = await _context.SerialDetails.FindAsync(id);
            if (serialDetail == null)
            {
                return NotFound();
            }

            _context.SerialDetails.Remove(serialDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SerialDetailExists(int id)
        {
            return (_context.SerialDetails?.Any(e => e.SerialDetailId == id)).GetValueOrDefault();
        }
    }
}
