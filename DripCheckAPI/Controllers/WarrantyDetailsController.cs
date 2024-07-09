using DripCheckAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/WarrantyDetails/Requested
        [HttpGet("Requested")]
        public async Task<ActionResult<IEnumerable<WarrantyDetail>>> GetWarrantyDetailsRequested()
        {
            if (_context.WarrantyDetails == null)
            {
                return NotFound();
            }
            return await _context.WarrantyDetails.Where(wd => wd.WarrantyStatus == "Requested").ToListAsync();
        }


        // PUT: api/WarrantyDetails/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Admin/{id}")]
        public async Task<IActionResult> PutWarrantyDetailAdmin(int id, int duration)
        {
            var warrantyDetail = await _context.WarrantyDetails.FindAsync(id);

            if (warrantyDetail == null)
            {
                return NotFound(new { Message = "Warranty Not Found!" });
            }

            warrantyDetail.ExpirationDate = warrantyDetail.ExpirationDate.AddYears(duration);
            warrantyDetail.WarrantyStatus = "Active";

            _context.WarrantyDetails.Update(warrantyDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                if (!_context.WarrantyDetails.Any(e => e.WarrantyDetailId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw (ex);
                }
            }

            return NoContent();
            
        }

        // PUT: api/WarrantyDetails/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("User/{id}")]
        public async Task<IActionResult> PutWarrantyDetailUser(int id, int duration)
        {
            var warrantyDetail = await _context.WarrantyDetails.FindAsync(id);

            if (warrantyDetail == null)
            {
                return NotFound(new { Message = "Warranty Not Found!" });
            }

            warrantyDetail.ReqDuration = duration;
            warrantyDetail.WarrantyStatus = "Requested";

            _context.WarrantyDetails.Update(warrantyDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_context.WarrantyDetails.Any(e => e.WarrantyDetailId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw (ex);
                }
            }

            return NoContent();

        }

        // POST: api/WarrantyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WarrantyDetail>> PostWarrantyDetail(WarrantyDetail warrantyDetail)
        {
          if (_context.WarrantyDetails == null)
          {
              return Problem("Entity set 'ApplicationDbContext.WarrantyDetails'  is null.");
          }
            _context.WarrantyDetails.Add(warrantyDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarrantyDetail", new { id = warrantyDetail.WarrantyDetailId }, warrantyDetail);
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

            return NoContent();
        }

        private bool WarrantyDetailExists(int id)
        {
            return (_context.WarrantyDetails?.Any(e => e.WarrantyDetailId == id)).GetValueOrDefault();
        }
    }
}
