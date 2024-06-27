using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;
using System.Security.Cryptography;

namespace DripCheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetails()
        {
          if (_context.ProductDetails == null)
          {
              return NotFound();
          }
            return await _context.ProductDetails.ToListAsync();
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(string id)
        {
          if (_context.ProductDetails == null)
          {
              return NotFound();
          }
            var productDetail = await _context.ProductDetails.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;
        }

        // GET: api/ProductDetails/SerialNumber/{serialNumber}
        [HttpGet("SerialNumber/{serialNumber}")]
        public async Task<ActionResult<ProductDetail>> GetBySerialNumber(string serialNumber)
        {
            var productDetail = await _context.ProductDetails.FirstOrDefaultAsync(s => s.SerialNumber == serialNumber);
            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;

        }

        // PUT: api/ProductDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(string id, ProductDetail productDetail)
        {
            if (id != productDetail.SerialNumber)
            {
                return BadRequest();
            }

            _context.Entry(productDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok(await _context.ProductDetails.ToListAsync());

        }

        // POST: api/ProductDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        {
          if (_context.ProductDetails == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ProductDetails'  is null.");
          }
            productDetail.SerialNumber = await GenerateUniqueSerialNumberAsync();
            _context.ProductDetails.Add(productDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductDetailExists(productDetail.SerialNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetProductDetail", new { id = productDetail.SerialNumber }, productDetail);
            return Ok(await _context.ProductDetails.ToListAsync());

        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            if (_context.ProductDetails == null)
            {
                return NotFound();
            }
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            _context.ProductDetails.Remove(productDetail);
            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok(await _context.ProductDetails.ToListAsync());
        }

        private async Task<string> GenerateUniqueSerialNumberAsync()
        {
            string serialNumber;
            do
            {
                serialNumber = GenerateRandomSerialNumber();
            } while (await _context.ProductDetails.AnyAsync(p => p.SerialNumber == serialNumber));

            return serialNumber;
        }

        private string GenerateRandomSerialNumber()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[8];
                rng.GetBytes(bytes);

                long number = BitConverter.ToInt64(bytes, 0) & 0x7FFFFFFFFFFFFFFF;

                return number.ToString("D15").Substring(0,15);
            }
        }

        private bool ProductDetailExists(string id)
        {
            return (_context.ProductDetails?.Any(e => e.SerialNumber == id)).GetValueOrDefault();
        }
    }
}
