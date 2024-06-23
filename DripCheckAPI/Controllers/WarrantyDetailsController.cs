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
    public class WarrantyDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WarrantyDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WarrantyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrantyDetail>>> GetWarrantyDetails()
        {
          if (_context.WarrantyDetails == null)
          {
              return NotFound();
          }
            return await _context.WarrantyDetails.ToListAsync();
        }

        // GET: api/WarrantyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrantyDetail>> GetWarrantyDetail(int id)
        {
          if (_context.WarrantyDetails == null)
          {
              return NotFound();
          }
            var warrantyDetail = await _context.WarrantyDetails.FindAsync(id);

            if (warrantyDetail == null)
            {
                return NotFound();
            }

            return warrantyDetail;
        }

        // PUT: api/WarrantyDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarrantyDetail(int id, WarrantyDetail warrantyDetail)
        {
            if (id != warrantyDetail.WarrantyDetailId)
            {
                return BadRequest();
            }

            _context.Entry(warrantyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarrantyDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok(await _context.WarrantyDetails.ToListAsync());
        }

        // POST: api/WarrantyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WarrantyDetail>> PostWarrantyDetail(WarrantyDetail warrantyDetail)
        {
          if (_context.WarrantyDetails == null)
          {
              return Problem("Entity set 'WarrantyDetailContext.WarrantyDetails'  is null.");
          }
            _context.WarrantyDetails.Add(warrantyDetail);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetWarrantyDetail", new { id = warrantyDetail.WarrantyDetailId }, warrantyDetail);
            return Ok(await _context.WarrantyDetails.ToListAsync());
        }

        // DELETE: api/WarrantyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarrantyDetail(int id)
        {
            if (_context.WarrantyDetails == null)
            {
                return NotFound();
            }
            var warrantyDetail = await _context.WarrantyDetails.FindAsync(id);
            if (warrantyDetail == null)
            {
                return NotFound();
            }

            _context.WarrantyDetails.Remove(warrantyDetail);
            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok(await _context.WarrantyDetails.ToListAsync());
        }

        private bool WarrantyDetailExists(int id)
        {
            return (_context.WarrantyDetails?.Any(e => e.WarrantyDetailId == id)).GetValueOrDefault();
        }
    }
}
