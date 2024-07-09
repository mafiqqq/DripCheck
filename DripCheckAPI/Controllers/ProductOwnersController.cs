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

            var productOwnerDetails = await _context.ProductOwners
            .Join(
                _context.WarrantyDetails,
                po => po.WarrantyDetailId,
                wd => wd.WarrantyDetailId,
                (po, wd) => new { po, wd }
                )
            .Join(
                _context.ProductDetails,
                combined => combined.po.ProductDetailId,
                pd => pd.ProductDetailId,
                (combined, pd) => new GetFullProductDescDto
                {
                    ProductOwnerId = combined.po.ProductOwnerId,
                    OwnerFirstName = combined.po.OwnerFirstName,
                    OwnerLastName = combined.po.OwnerLastName,
                    EmailAddress = combined.po.EmailAddress,
                    PhoneNum = combined.po.PhoneNum,
                    ProductSerialNumber = combined.po.ProductSerialNumber,
                    ExpirationDate = combined.wd.ExpirationDate.ToString("yyyy-MM-dd"),
                    WarrantyStatus = combined.wd.WarrantyStatus,
                    ProductModel = pd.ProductModel,
                    ProductBrand = pd.ProductBrand,
                    ProductColor = pd.ProductColor,
                    ProductImageUrl1 = pd.ProductImageUrl1,
                    ProductImageUrl2 = pd.ProductImageUrl2,
                    ProductImageUrl3 = pd.ProductImageUrl3,
                    ProductPrice = pd.ProductPrice,
                    ProductHeight = pd.ProductHeight,
                    ProductWidth = pd.ProductWidth,
                    ProductWeight = pd.ProductWeight,
                    ProductDisplaySize = pd.ProductDisplaySize,
                    ProductDisplayType = pd.ProductDisplayType,
                    ProductResolution = pd.ProductResolution,
                    ProductProcessor = pd.ProductProcessor,
                    ProductOS = pd.ProductOS,
                    ProductMemoryRAM = pd.ProductMemoryRAM,
                    ProductMemoryROM = pd.ProductMemoryROM,
                    ProductRearCamera = pd.ProductRearCamera,
                    ProductFrontCamera = pd.ProductFrontCamera,
                    ProductBattery = pd.ProductBattery,
                }
            )
            .FirstOrDefaultAsync();

            if (productOwnerDetails == null)
            {
                return NotFound();
            }

            var getFullProductDescDto = new GetFullProductDescDto
            {
                ProductOwnerId = productOwnerDetails.ProductOwnerId,
                OwnerFirstName = productOwnerDetails.OwnerFirstName,
                OwnerLastName = productOwnerDetails.OwnerLastName,
                EmailAddress = productOwnerDetails.EmailAddress,
                PhoneNum = productOwnerDetails.PhoneNum,
                ProductSerialNumber = productOwnerDetails.ProductSerialNumber,
                ExpirationDate = productOwnerDetails.ExpirationDate,
                WarrantyStatus = productOwnerDetails.WarrantyStatus,
                ProductModel = productOwnerDetails.ProductModel,
                ProductBrand = productOwnerDetails.ProductBrand,
                ProductColor = productOwnerDetails.ProductColor,
                ProductImageUrl1 = productOwnerDetails.ProductImageUrl1,
                ProductImageUrl2 = productOwnerDetails.ProductImageUrl2,
                ProductImageUrl3 = productOwnerDetails.ProductImageUrl3,
                ProductPrice = productOwnerDetails.ProductPrice,
                ProductHeight = productOwnerDetails.ProductHeight,
                ProductWidth = productOwnerDetails.ProductWidth,
                ProductWeight = productOwnerDetails.ProductWeight,
                ProductDisplaySize = productOwnerDetails.ProductDisplaySize,
                ProductDisplayType = productOwnerDetails.ProductDisplayType,
                ProductResolution = productOwnerDetails.ProductResolution,
                ProductProcessor = productOwnerDetails.ProductProcessor,
                ProductOS = productOwnerDetails.ProductOS,
                ProductMemoryRAM = productOwnerDetails.ProductMemoryRAM,
                ProductMemoryROM = productOwnerDetails.ProductMemoryROM,
                ProductRearCamera = productOwnerDetails.ProductRearCamera,
                ProductFrontCamera = productOwnerDetails.ProductFrontCamera,
                ProductBattery = productOwnerDetails.ProductBattery,
            };

            //return await _context.ProductOwners.ToListAsync();
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
            var productOwnerDetails = await _context.ProductOwners
                .Where(po => po.ProductOwnerId == id)
                .Join(
                  _context.WarrantyDetails,
                  po => po.WarrantyDetailId,
                  wd => wd.WarrantyDetailId,
                  (po, wd) => new { po, wd }
                  )
              .Join(
                  _context.ProductDetails,
                  combined => combined.po.ProductDetailId,
                  pd => pd.ProductDetailId,
                  (combined, pd) => new GetFullProductDescDto
                  {
                      ProductOwnerId = combined.po.ProductOwnerId,
                      OwnerFirstName = combined.po.OwnerFirstName,
                      OwnerLastName = combined.po.OwnerLastName,
                      EmailAddress = combined.po.EmailAddress,
                      PhoneNum = combined.po.PhoneNum,
                      ProductSerialNumber = combined.po.ProductSerialNumber,
                      WarrantyDetailId = combined.wd.WarrantyDetailId,
                      ExpirationDate = combined.wd.ExpirationDate.ToString("yyyy-MM-dd"),
                      WarrantyStatus = combined.wd.WarrantyStatus,
                      ProductModel = pd.ProductModel,
                      ProductBrand = pd.ProductBrand,
                      ProductColor = pd.ProductColor,
                      ProductImageUrl1 = pd.ProductImageUrl1,
                      ProductImageUrl2 = pd.ProductImageUrl2,
                      ProductImageUrl3 = pd.ProductImageUrl3,
                      ProductPrice = pd.ProductPrice,
                      ProductHeight = pd.ProductHeight,
                      ProductWidth = pd.ProductWidth,
                      ProductWeight = pd.ProductWeight,
                      ProductDisplaySize = pd.ProductDisplaySize,
                      ProductDisplayType = pd.ProductDisplayType,
                      ProductResolution = pd.ProductResolution,
                      ProductProcessor = pd.ProductProcessor,
                      ProductOS = pd.ProductOS,
                      ProductMemoryRAM = pd.ProductMemoryRAM,
                      ProductMemoryROM = pd.ProductMemoryROM,
                      ProductRearCamera = pd.ProductRearCamera,
                      ProductFrontCamera = pd.ProductFrontCamera,
                      ProductBattery = pd.ProductBattery,
                  }
              )
              .FirstOrDefaultAsync();

            if (productOwnerDetails == null)
            {
                return NotFound();
            }

            var getFullProductDescDto = new GetFullProductDescDto
            {
                ProductOwnerId = productOwnerDetails.ProductOwnerId,
                OwnerFirstName = productOwnerDetails.OwnerFirstName,
                OwnerLastName = productOwnerDetails.OwnerLastName,
                EmailAddress = productOwnerDetails.EmailAddress,
                PhoneNum = productOwnerDetails.PhoneNum,
                ProductSerialNumber = productOwnerDetails.ProductSerialNumber,
                WarrantyDetailId = productOwnerDetails.WarrantyDetailId,
                ExpirationDate = productOwnerDetails.ExpirationDate,
                WarrantyStatus = productOwnerDetails.WarrantyStatus,
                ProductModel = productOwnerDetails.ProductModel,
                ProductBrand = productOwnerDetails.ProductBrand,
                ProductColor = productOwnerDetails.ProductColor,
                ProductImageUrl1 = productOwnerDetails.ProductImageUrl1,
                ProductImageUrl2 = productOwnerDetails.ProductImageUrl2,
                ProductImageUrl3 = productOwnerDetails.ProductImageUrl3,
                ProductPrice = productOwnerDetails.ProductPrice,
                ProductHeight = productOwnerDetails.ProductHeight,
                ProductWidth = productOwnerDetails.ProductWidth,
                ProductWeight = productOwnerDetails.ProductWeight,
                ProductDisplaySize = productOwnerDetails.ProductDisplaySize,
                ProductDisplayType = productOwnerDetails.ProductDisplayType,
                ProductResolution = productOwnerDetails.ProductResolution,
                ProductProcessor = productOwnerDetails.ProductProcessor,
                ProductOS = productOwnerDetails.ProductOS,
                ProductMemoryRAM = productOwnerDetails.ProductMemoryRAM,
                ProductMemoryROM = productOwnerDetails.ProductMemoryROM,
                ProductRearCamera = productOwnerDetails.ProductRearCamera,
                ProductFrontCamera = productOwnerDetails.ProductFrontCamera,
                ProductBattery = productOwnerDetails.ProductBattery,
            };


            //return productOwner;
            return Ok(getFullProductDescDto);
        }

        // GET: api/ProductOwners/SerialNumber/{serialNumber}
        [HttpGet("SerialNumber/{serialNumber}")]
        public async Task<ActionResult<int>> GetBySerialNumber(string serialNumber)
        {

            var productOwnerDetails = await _context.ProductOwners
                .Where(po => po.ProductSerialNumber == serialNumber)
                .Join(
                    _context.WarrantyDetails,
                    po => po.WarrantyDetailId,
                    wd => wd.WarrantyDetailId,
                    (po, wd) => new { po, wd }
                    )
                .Join(
                    _context.ProductDetails,
                    combined => combined.po.ProductDetailId,
                    pd => pd.ProductDetailId,
                    (combined, pd) => new GetFullProductDescDto
                    {
                        ProductOwnerId = combined.po.ProductOwnerId,
                        OwnerFirstName = combined.po.OwnerFirstName,
                        OwnerLastName = combined.po.OwnerLastName,
                        EmailAddress = combined.po.EmailAddress,
                        PhoneNum = combined.po.PhoneNum,
                        ProductSerialNumber = combined.po.ProductSerialNumber,
                        ExpirationDate = combined.wd.ExpirationDate.ToString("yyyy-MM-dd"),
                        WarrantyStatus = combined.wd.WarrantyStatus,
                        ProductModel = pd.ProductModel,
                        ProductBrand = pd.ProductBrand,
                        ProductColor = pd.ProductColor,
                        ProductImageUrl1 = pd.ProductImageUrl1,
                        ProductImageUrl2 = pd.ProductImageUrl2,
                        ProductImageUrl3 = pd.ProductImageUrl3,
                        ProductPrice = pd.ProductPrice,
                        ProductHeight = pd.ProductHeight,
                        ProductWidth = pd.ProductWidth,
                        ProductWeight = pd.ProductWeight,
                        ProductDisplaySize = pd.ProductDisplaySize,
                        ProductDisplayType = pd.ProductDisplayType,
                        ProductResolution = pd.ProductResolution,
                        ProductProcessor = pd.ProductProcessor,
                        ProductOS = pd.ProductOS,
                        ProductMemoryRAM = pd.ProductMemoryRAM,
                        ProductMemoryROM = pd.ProductMemoryROM,
                        ProductRearCamera = pd.ProductRearCamera,
                        ProductFrontCamera = pd.ProductFrontCamera,
                        ProductBattery = pd.ProductBattery,
                    }
                )
                .FirstOrDefaultAsync();

            if (productOwnerDetails == null)
            {
                return NotFound();
            }

            var getFullProductDescDto = new GetFullProductDescDto
            {
                ProductOwnerId = productOwnerDetails.ProductOwnerId,
                OwnerFirstName = productOwnerDetails.OwnerFirstName,
                OwnerLastName = productOwnerDetails.OwnerLastName,
                EmailAddress = productOwnerDetails.EmailAddress,
                PhoneNum = productOwnerDetails.PhoneNum,
                ProductSerialNumber = productOwnerDetails.ProductSerialNumber,
                ExpirationDate = productOwnerDetails.ExpirationDate,
                WarrantyStatus = productOwnerDetails.WarrantyStatus,
                ProductModel = productOwnerDetails.ProductModel,
                ProductBrand = productOwnerDetails.ProductBrand,
                ProductColor = productOwnerDetails.ProductColor,
                ProductImageUrl1 = productOwnerDetails.ProductImageUrl1,
                ProductImageUrl2 = productOwnerDetails.ProductImageUrl2,
                ProductImageUrl3 = productOwnerDetails.ProductImageUrl3,
                ProductPrice = productOwnerDetails.ProductPrice,
                ProductHeight = productOwnerDetails.ProductHeight,
                ProductWidth = productOwnerDetails.ProductWidth,
                ProductWeight = productOwnerDetails.ProductWeight,
                ProductDisplaySize = productOwnerDetails.ProductDisplaySize,
                ProductDisplayType = productOwnerDetails.ProductDisplayType,
                ProductResolution = productOwnerDetails.ProductResolution,
                ProductProcessor = productOwnerDetails.ProductProcessor,
                ProductOS = productOwnerDetails.ProductOS,
                ProductMemoryRAM = productOwnerDetails.ProductMemoryRAM,
                ProductMemoryROM = productOwnerDetails.ProductMemoryROM,
                ProductRearCamera = productOwnerDetails.ProductRearCamera,
                ProductFrontCamera = productOwnerDetails.ProductFrontCamera,
                ProductBattery = productOwnerDetails.ProductBattery,
            };


            //return Ok(getFullProductDescDto);
            return getFullProductDescDto.ProductOwnerId;

        }

        // GET: api/ProductDetails/Warranty
        [HttpGet("Warranty")]
        public async Task<ActionResult<ProductOwner>> GetDetailsOfWarranty()
        {
            if (_context.ProductOwners == null)
            {
                return NotFound();
            }

            var productOwners = await _context.ProductOwners
            .Join(
                _context.WarrantyDetails,
                po => po.WarrantyDetailId,
                wd => wd.WarrantyDetailId,
                (po, wd) => new
                {
                    po.ProductOwnerId,
                    po.OwnerFirstName,
                    po.OwnerLastName,
                    po.ProductSerialNumber,
                    wd.ExpirationDate,
                    wd.WarrantyStatus,
                    wd.WarrantyDetailId
                })
            .ToListAsync();

            var productOwnersDto = productOwners.Select(po => new GetWarrantyDetailDto
            {
                ProductOwnerId = po.ProductOwnerId,
                OwnerFirstName = po.OwnerFirstName,
                OwnerLastName = po.OwnerLastName,
                ProductSerialNumber = po.ProductSerialNumber,
                ExpirationDate = po.ExpirationDate.ToString("yyyy-MM-dd"),  // Format date here
                WarrantyStatus = po.WarrantyStatus,
                WarrantyDetailId = po.WarrantyDetailId
            }).ToList();

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
            .Join(
                _context.WarrantyDetails,
                po => po.WarrantyDetailId,
                wd => wd.WarrantyDetailId,
                (po, wd) => new
                {
                    po.ProductOwnerId,
                    po.OwnerFirstName,
                    po.OwnerLastName,
                    po.ProductSerialNumber,
                    wd.ExpirationDate,
                    wd.WarrantyStatus,
                    wd.WarrantyDetailId,
                    wd.ReqDuration
                })
            .Where(result => result.WarrantyStatus == "Requested")
            .ToListAsync();

            var productOwnersDto = productOwners.Select(po => new GetWarrantyDetailDto
            {
                ProductOwnerId = po.ProductOwnerId,
                OwnerFirstName = po.OwnerFirstName,
                OwnerLastName = po.OwnerLastName,
                ProductSerialNumber = po.ProductSerialNumber,
                ExpirationDate = po.ExpirationDate.ToString("yyyy-MM-dd"),  // Format date here
                WarrantyStatus = po.WarrantyStatus,
                WarrantyDetailId = po.WarrantyDetailId,
                ReqDuration = po.ReqDuration
            }).ToList();

            return Ok(productOwnersDto);
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

        //// POST: api/ProductOwners
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<ProductOwner>> PostProductOwner(ProductOwner productOwner)
        //{
        //  if (_context.ProductOwners == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.ProductOwners'  is null.");
        //  }

        //    // Configure warranty expiration date and status
        //    var warrantyDetail = new WarrantyDetail
        //    {
        //        ExpirationDate = DateTime.Now.AddYears(2).Date,
        //        WarrantyStatus = "Active",
        //    };


        //    productOwner.ProductSerialNumber = await GenerateUniqueSerialNumberAsync();

        //    // Query ProductDetail
        //    var productDetail = await _context.ProductDetails.FirstOrDefaultAsync(pd => pd.ProductDetailId == productOwner.ProductDetailId);

        //    if (productDetail == null) { 
        //        return BadRequest();
        //    }


        //    var newProductOwner = new ProductOwner
        //    {
        //        OwnerFirstName = productOwner.OwnerFirstName,
        //        OwnerLastName = productOwner.OwnerLastName,
        //        EmailAddress = productOwner.EmailAddress,
        //        PhoneNum = productOwner.PhoneNum,
        //        ProductSerialNumber = productOwner.ProductSerialNumber,
        //        ProductDetailId = productOwner.ProductDetailId,
        //        ProductDetail = productDetail,
        //        WarrantyDetail = warrantyDetail
        //    };

        //    // Setting the reverse navigation property
        //    warrantyDetail.ProductOwner = newProductOwner;
        //    productDetail.ProductOwners.Add(newProductOwner);

        //    _context.ProductOwners.Add(newProductOwner);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.ProductOwners.ToListAsync());
        //}

        // POST
        [HttpPost]
        public async Task<ActionResult<int>> PostProductOwner(CreateProductOwnerDto createProductOwnerDto)
        {
            if (_context.ProductOwners == null) 
            {
                return Problem("Entity set 'ApplicationDbContext.ProductOwners'  is null.");
            }

            // Create a new WarrantyDetail instance - Because we create a new warranty automatically user buy
            var warrantyDetail = new WarrantyDetail
            {
                ExpirationDate = DateTime.Now.AddYears(2).Date,
                WarrantyStatus = "Active"
            };

            // Add the WarrantyDetail entity to the context
            _context.WarrantyDetails.Add(warrantyDetail);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create a new ProductOwner instance
            var productOwner = new ProductOwner()
            {
                OwnerFirstName = createProductOwnerDto.OwnerFirstName,
                OwnerLastName = createProductOwnerDto.OwnerLastName,
                EmailAddress = createProductOwnerDto.EmailAddress,
                PhoneNum    = createProductOwnerDto.PhoneNum,
                ProductDetailId = createProductOwnerDto.ProductDetailId,
                ProductSerialNumber = await GenerateUniqueSerialNumberAsync(),
                WarrantyDetailId = warrantyDetail.WarrantyDetailId,
            };

            // Add the ProductOwner entity to the context
            _context.ProductOwners.Add(productOwner);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Create DTO for the newly created entities - so we can define what exactly we want to return to response 
            var productOwnerDto = new ProductOwnerDto
            {
                ProductOwnerId = productOwner.ProductOwnerId,
                OwnerFirstName = productOwner.OwnerFirstName,
                OwnerLastName = productOwner.OwnerLastName,
                EmailAddress = productOwner.EmailAddress,
                PhoneNum = productOwner.PhoneNum,
                ProductSerialNumber = productOwner.ProductSerialNumber,
                ProductDetailId = productOwner.ProductDetailId,
                WarrantyDetailId = productOwner.WarrantyDetailId,
            };

            var warrantyDetailDto = new WarrantyDetailDto
            {
                WarrantyDetailId = warrantyDetail.WarrantyDetailId,
                ExpirationDate = warrantyDetail.ExpirationDate,
                WarrantyStatus = warrantyDetail.WarrantyStatus
            };


            // but we decided to only return ID sbb we using router-navigate at Frontend to navigate to view-product/$id page tu
            return productOwnerDto.ProductOwnerId;

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
