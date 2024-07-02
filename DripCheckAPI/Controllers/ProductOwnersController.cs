using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;
using System.Security.Cryptography;
using Humanizer;

namespace DripCheckAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOwnersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductOwnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOwner>>> GetProductOwners()
        {
          if (_context.ProductOwners == null)
          {
              return NotFound();
          }
            return await _context.ProductOwners.ToListAsync();
        }

        // GET: api/ProductOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOwner>> GetProductOwner(int id)
        {
          if (_context.ProductOwners == null)
          {
              return NotFound();
          }
            var productOwner = await _context.ProductOwners.FindAsync(id);

            if (productOwner == null)
            {
                return NotFound();
            }

            return productOwner;
        }

        // GET: api/ProductDetails/SerialNumber/{serialNumber}
        [HttpGet("SerialNumber/{serialNumber}")]
        public async Task<ActionResult<ProductOwner>> GetBySerialNumber(string serialNumber)
        {
            var productOwner = await _context.ProductOwners.FirstOrDefaultAsync(s => s.ProductSerialNumber == serialNumber);
            if (productOwner == null)
            {
                return NotFound();
            }

            return productOwner;

        }

        // PUT: api/ProductOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductOwner(int id, ProductOwner productOwner)
        {
            if (id != productOwner.ProductOwnerId)
            {
                return BadRequest();
            }

            _context.Entry(productOwner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOwnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.ProductOwners.ToListAsync());
        }

        // POST: api/ProductOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductOwner>> PostProductOwner(ProductOwner productOwner)
        {
          if (_context.ProductOwners == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ProductOwners'  is null.");
          }

            // Configure warranty expiration date and status
            var warrantyDetail = new WarrantyDetail
            {
                ExpirationDate = DateTime.Now.AddYears(2).Date,
                WarrantyStatus = "Active",
            };


            productOwner.ProductSerialNumber = await GenerateUniqueSerialNumberAsync();
            
            // Query ProductDetail
            var productDetail = await _context.ProductDetails.FirstOrDefaultAsync(pd => pd.ProductDetailId == productOwner.ProductDetailId);

            if (productDetail == null) { 
                return BadRequest();
            }
            
            
            var newProductOwner = new ProductOwner
            {
                OwnerFirstName = productOwner.OwnerFirstName,
                OwnerLastName = productOwner.OwnerLastName,
                EmailAddress = productOwner.EmailAddress,
                PhoneNum = productOwner.PhoneNum,
                ProductSerialNumber = productOwner.ProductSerialNumber,
                ProductDetailId = productOwner.ProductDetailId,
                ProductDetail = productDetail,
                WarrantyDetail = warrantyDetail
            };

            // Setting the reverse navigation property
            warrantyDetail.ProductOwner = newProductOwner;
            productDetail.ProductOwners.Add(newProductOwner);

            _context.ProductOwners.Add(newProductOwner);
            await _context.SaveChangesAsync();

            return Ok(await _context.ProductOwners.ToListAsync());
        }

        // DELETE: api/ProductOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOwner(int id)
        {
            if (_context.ProductOwners == null)
            {
                return NotFound();
            }
            var productOwner = await _context.ProductOwners.FindAsync(id);
            if (productOwner == null)
            {
                return NotFound();
            }

            _context.ProductOwners.Remove(productOwner);
            await _context.SaveChangesAsync();

            return Ok(await _context.ProductOwners.ToListAsync());
        }

        private async Task<string> GenerateUniqueSerialNumberAsync()
        {
            string serialNumber;
            do
            {
                serialNumber = GenerateRandomSerialNumber();
            } while (await _context.ProductOwners.AnyAsync(p => p.ProductSerialNumber == serialNumber));

            return serialNumber;
        }

        private string GenerateRandomSerialNumber()
        { 
            using (var rng = RandomNumberGenerator.Create()) 
            {
                byte[] bytes = new byte[8];
                rng.GetBytes(bytes);

                long number = BitConverter.ToInt64(bytes, 0) & 0x7FFFFFFFFFFFFFFF;

                return number.ToString("D15").Substring(0, 15);
            }
        }

        private bool ProductOwnerExists(int id)
        {
            return (_context.ProductOwners?.Any(e => e.ProductOwnerId == id)).GetValueOrDefault();
        }
    }
}
