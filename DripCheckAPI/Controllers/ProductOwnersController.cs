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
using DripCheckAPI.Models.DTO;

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

            var getFullProductDescDto = await _context.ProductOwners
                .Include(po => po.WarrantyDetail)
                .Include(po => po.ProductDetail)
                .Include(po => po.Login)
                .Include(po => po.ProductSerialNumber)
                .Select(po => new GetFullProductDescDto
                {
                    ProductOwnerId = po.ProductOwnerId,
                    OwnerFirstName = po.OwnerFirstName,
                    OwnerLastName = po.OwnerLastName,
                    EmailAddress = po.EmailAddress,
                    PhoneNum = po.PhoneNum,
                    SerialNumber = po.ProductSerialNumber.SerialNumber,
                    WarrantyDetailId = po.WarrantyDetailId,
                    ExpirationDate = po.WarrantyDetail.ExpirationDate.ToString("yyyy-MM-dd"),
                    WarrantyStatus = po.WarrantyDetail.WarrantyStatus,
                    ProductModel = po.ProductDetail.ProductModel,
                    ProductBrand = po.ProductDetail.ProductBrand,
                    ProductColor = po.ProductDetail.ProductColor,
                    ProductImageUrl1 = po.ProductDetail.ProductImageUrl1,
                    ProductImageUrl2 = po.ProductDetail.ProductImageUrl2,
                    ProductImageUrl3 = po.ProductDetail.ProductImageUrl3,
                    ProductPrice = po.ProductDetail.ProductPrice,
                    ProductHeight = po.ProductDetail.ProductHeight,
                    ProductWidth = po.ProductDetail.ProductWidth,
                    ProductWeight = po.ProductDetail.ProductWeight,
                    ProductDisplaySize = po.ProductDetail.ProductDisplaySize,
                    ProductDisplayType = po.ProductDetail.ProductDisplayType,
                    ProductResolution = po.ProductDetail.ProductResolution,
                    ProductProcessor = po.ProductDetail.ProductProcessor,
                    ProductOS = po.ProductDetail.ProductOS,
                    ProductMemoryRAM = po.ProductDetail.ProductMemoryRAM,
                    ProductMemoryROM = po.ProductDetail.ProductMemoryROM,
                    ProductRearCamera = po.ProductDetail.ProductRearCamera,
                    ProductFrontCamera = po.ProductDetail.ProductFrontCamera,
                    ProductBattery = po.ProductDetail.ProductBattery,
                    ProductRelDate = po.ProductDetail.ProductRelDate,
                    LoginId = po.Login.LoginId,
                }).FirstOrDefaultAsync();

            if (getFullProductDescDto == null)
            {
                return NotFound();
            }

            return Ok(getFullProductDescDto);
        }

        // GET: api/ProductOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOwner>> GetProductOwner(int id)
        {
            if (_context.ProductOwners == null)
            {
                return NotFound();
            }

            var getFullProductDescDto = await _context.ProductOwners
                .Include(po => po.WarrantyDetail)
                .Include(po => po.ProductDetail)
                .Include(po => po.Login)
                .Include(po => po.ProductSerialNumber)
                .Where(po => po.LoginId == id)
                .Select(po => new GetFullProductDescDto
                {
                    ProductOwnerId = po.ProductOwnerId,
                    OwnerFirstName = po.OwnerFirstName,
                    OwnerLastName = po.OwnerLastName,
                    EmailAddress = po.EmailAddress,
                    PhoneNum = po.PhoneNum,
                    SerialNumber = po.ProductSerialNumber.SerialNumber,
                    WarrantyDetailId = po.WarrantyDetailId,
                    ExpirationDate = po.WarrantyDetail.ExpirationDate.ToString("yyyy-MM-dd"),
                    WarrantyStatus = po.WarrantyDetail.WarrantyStatus,
                    ProductModel = po.ProductDetail.ProductModel,
                    ProductBrand = po.ProductDetail.ProductBrand,
                    ProductColor = po.ProductDetail.ProductColor,
                    ProductImageUrl1 = po.ProductDetail.ProductImageUrl1,
                    ProductImageUrl2 = po.ProductDetail.ProductImageUrl2,
                    ProductImageUrl3 = po.ProductDetail.ProductImageUrl3,
                    ProductPrice = po.ProductDetail.ProductPrice,
                    ProductHeight = po.ProductDetail.ProductHeight,
                    ProductWidth = po.ProductDetail.ProductWidth,
                    ProductWeight = po.ProductDetail.ProductWeight,
                    ProductDisplaySize = po.ProductDetail.ProductDisplaySize,
                    ProductDisplayType = po.ProductDetail.ProductDisplayType,
                    ProductResolution = po.ProductDetail.ProductResolution,
                    ProductProcessor = po.ProductDetail.ProductProcessor,
                    ProductOS = po.ProductDetail.ProductOS,
                    ProductMemoryRAM = po.ProductDetail.ProductMemoryRAM,
                    ProductMemoryROM = po.ProductDetail.ProductMemoryROM,
                    ProductRearCamera = po.ProductDetail.ProductRearCamera,
                    ProductFrontCamera = po.ProductDetail.ProductFrontCamera,
                    ProductBattery = po.ProductDetail.ProductBattery,
                    ProductRelDate = po.ProductDetail.ProductRelDate,
                    LoginId = po.Login.LoginId,
                }).FirstOrDefaultAsync();

            if (getFullProductDescDto == null)
            {
                return NotFound();
            }

            return Ok(getFullProductDescDto);
        }

        // GET: api/ProductOwners/Warranty
        [HttpGet("Warranty")]
        public async Task<ActionResult<ProductOwner>> GetDetailsOfWarranty()
        {
            if (_context.ProductOwners == null)
            {
                return NotFound();
            }

            var productOwnersDto = await _context.ProductOwners
                .Include(po => po.WarrantyDetail)
                .Include(po => po.ProductSerialNumber)
                .Include(po => po.Login)
                .Where(po => po.WarrantyDetail.WarrantyStatus != "Requested")
                .Select(po => new GetWarrantyDetailDto
                {
                    ProductOwnerId = po.ProductOwnerId,
                    OwnerFirstName = po.OwnerFirstName,
                    OwnerLastName = po.OwnerLastName,
                    SerialNumber = po.ProductSerialNumber.SerialNumber,
                    ExpirationDate = po.WarrantyDetail.ExpirationDate.ToString("yyyy-MM-dd"),  // Format date here
                    WarrantyStatus = po.WarrantyDetail.WarrantyStatus,
                    WarrantyDetailId = po.WarrantyDetailId,
                    LoginId = po.LoginId
                }).ToListAsync();

            return Ok(productOwnersDto);
        }

        // GET: api/ProductDetails/RequestedWarranty
        [HttpGet("RequestedWarranty")]
        public async Task<ActionResult<ProductOwner>> GetDetailsOfRequestedWarranty()
        {
            if (_context.ProductOwners == null)
            {
                return NotFound();
            }

            var productOwners = await _context.ProductOwners
                .Include(po => po.WarrantyDetail)
                .Include(po => po.ProductSerialNumber)
                .Include(po => po.Login)
                .Where(po => po.WarrantyDetail.WarrantyStatus == "Requested")
                .Select(po => new ProductOwnerDto
                {
                    ProductOwnerId = po.ProductOwnerId,
                    OwnerFirstName = po.OwnerFirstName,
                    OwnerLastName = po.OwnerLastName,
                    EmailAddress = po.EmailAddress,
                    PhoneNum = po.PhoneNum,
                    WarrantyDetailId = po.WarrantyDetailId,
                    LoginId = po.LoginId,
                    ProductDetailId = po.ProductDetailId,
                })
                .ToListAsync();

            return Ok(productOwners);
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

        // POST
        [HttpPost]
        public async Task<ActionResult<int>> PostProductOwner(CreateProductOwnerDto createProductOwnerDto)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                //Create a new WarrantyDetail instance
                var warrantyDetail = new WarrantyDetail
                {
                    ExpirationDate = DateTime.Now.AddYears(2),
                    WarrantyStatus = "Active"
                };

                //Get an available serialnumber
                var availableSerialNumber = await _context.ProductSerialNumbers
                    .Where(psn => psn.ProductDetailId == createProductOwnerDto.ProductDetailId && psn.isAvailable)
                    .FirstOrDefaultAsync();

                if (availableSerialNumber != null)
                {
                    throw new InvalidOperationException("No available serial number for this product");
                }

                //Create a new productOwner instance
                var productOwner = new ProductOwner
                {
                    OwnerFirstName = createProductOwnerDto.OwnerFirstName,
                    OwnerLastName = createProductOwnerDto.OwnerLastName,
                    EmailAddress = createProductOwnerDto.EmailAddress,
                    PhoneNum = createProductOwnerDto.PhoneNum,
                    ProductDetailId = createProductOwnerDto.ProductDetailId,
                    ProductSerialNumber = availableSerialNumber,
                    WarrantyDetail = warrantyDetail,
                    LoginId = createProductOwnerDto.LoginId
                };

                // Mark available serialNumber as false
                availableSerialNumber.isAvailable = false;

                // Add productOwner entity to db context
                _context.ProductOwners.Add(productOwner);

                // Save all changes in one go
                _context.SaveChangesAsync();

                // Commit transaction
                await transaction.CommitAsync();

                // but we decided to only return ID sbb we using router-navigate at Frontend to navigate to view-product/$id page tu
                return productOwner.LoginId;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }

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

        private bool ProductOwnerExists(int id)
        {
            return (_context.ProductOwners?.Any(e => e.ProductOwnerId == id)).GetValueOrDefault();
        }
    }
}
