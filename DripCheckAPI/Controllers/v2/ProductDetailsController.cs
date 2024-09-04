using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;
using DripCheckAPI.Models.DTO;
using Azure.Core;
using Asp.Versioning;

namespace DripCheckAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
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

            var productDetailsDto = await _context.ProductDetails
                .Select(pd => new ProductDetailDto
                {
                    ProductDetailId = pd.ProductDetailId,
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
                    ProductRelDate = pd.ProductBattery,
                }).AsNoTracking().ToListAsync();

            return Ok(productDetailsDto);
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(int id)
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

            var productDetailsDto = new ProductDetailDto()
            {
                ProductDetailId = productDetail.ProductDetailId,
                ProductModel = productDetail.ProductModel,
                ProductBrand = productDetail.ProductBrand,
                ProductColor = productDetail.ProductColor,
                ProductImageUrl1 = productDetail.ProductImageUrl1,
                ProductImageUrl2 = productDetail.ProductImageUrl2,
                ProductImageUrl3 = productDetail.ProductImageUrl3,
                ProductPrice = productDetail.ProductPrice,
                ProductHeight = productDetail.ProductHeight,
                ProductWidth = productDetail.ProductWidth,
                ProductWeight = productDetail.ProductWeight,
                ProductDisplaySize = productDetail.ProductDisplaySize,
                ProductDisplayType = productDetail.ProductDisplayType,
                ProductResolution = productDetail.ProductResolution,
                ProductProcessor = productDetail.ProductProcessor,
                ProductOS = productDetail.ProductOS,
                ProductMemoryRAM = productDetail.ProductMemoryRAM,
                ProductMemoryROM = productDetail.ProductMemoryROM,
                ProductRearCamera = productDetail.ProductRearCamera,
                ProductFrontCamera = productDetail.ProductFrontCamera,
                ProductBattery = productDetail.ProductBattery,
                ProductRelDate = productDetail.ProductRelDate,
            };

            return Ok(productDetailsDto);
        }


        // PUT: api/ProductDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(int id, ProductDetail productDetail)
        {
            if (id != productDetail.ProductDetailId)
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

            return NoContent();
        }

        // PUT: api/ProductDetails/Restock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Restock/{id}")]
        public async Task<IActionResult> RestockProduct(int id, List<string> serialNumbers)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound(new { Message = "Product Not Found!" });
            }

            // Process each serial number
            var productSerialNumbers = serialNumbers.Select(serialNumber => new ProductSerialNumber
            {
                SerialNumber = serialNumber,
                isAvailable = true,
                ProductDetailId = productDetail.ProductDetailId // get ID here
            }).ToList();

            try
            {
                // Add serial numbers to the database
                _context.ProductSerialNumbers.AddRange(productSerialNumbers);
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

            return NoContent();
        }

        // POST: api/ProductDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        public async Task<ActionResult<ProductDetail>> PostProductDetail(CreateProductDetailDto createProductDetailDto)
        {

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var productDetail = new ProductDetail()
                {
                    ProductModel = createProductDetailDto.ProductModel,
                    ProductBrand = createProductDetailDto.ProductBrand,
                    ProductColor = createProductDetailDto.ProductColor,
                    ProductImageUrl1 = createProductDetailDto.ProductImageUrl1,
                    ProductImageUrl2 = createProductDetailDto.ProductImageUrl2,
                    ProductImageUrl3 = createProductDetailDto.ProductImageUrl3,
                    ProductPrice = createProductDetailDto.ProductPrice,
                    ProductHeight = createProductDetailDto.ProductHeight,
                    ProductWidth = createProductDetailDto.ProductWidth,
                    ProductWeight = createProductDetailDto.ProductWeight,
                    ProductDisplaySize = createProductDetailDto.ProductDisplaySize,
                    ProductDisplayType = createProductDetailDto.ProductDisplayType,
                    ProductResolution = createProductDetailDto.ProductResolution,
                    ProductProcessor = createProductDetailDto.ProductProcessor,
                    ProductOS = createProductDetailDto.ProductOS,
                    ProductMemoryRAM = createProductDetailDto.ProductMemoryRAM,
                    ProductMemoryROM = createProductDetailDto.ProductMemoryROM,
                    ProductRearCamera = createProductDetailDto.ProductRearCamera,
                    ProductFrontCamera = createProductDetailDto.ProductFrontCamera,
                    ProductBattery = createProductDetailDto.ProductBattery,
                    ProductRelDate = createProductDetailDto.ProductRelDate,
                };

                _context.ProductDetails.Add(productDetail); // alrdy save

                // Process each serial number
                var productSerialNumbers = createProductDetailDto.SerialNumbers.Select(serialNumber => new ProductSerialNumber
                {
                    SerialNumber = serialNumber,
                    isAvailable = true,
                    ProductDetailId = productDetail.ProductDetailId // get ID here
                }).ToList();

                // Add serial numbers to the database
                _context.ProductSerialNumbers.AddRange(productSerialNumbers);

                var productDetailDto = new ProductDetailDto
                {
                    ProductDetailId = productDetail.ProductDetailId,
                    ProductModel = productDetail.ProductModel,
                    ProductBrand = productDetail.ProductBrand,
                    ProductColor = productDetail.ProductColor,
                    ProductImageUrl1 = productDetail.ProductImageUrl1,
                    ProductImageUrl2 = productDetail.ProductImageUrl2,
                    ProductImageUrl3 = productDetail.ProductImageUrl3,
                    ProductPrice = productDetail.ProductPrice,
                    ProductHeight = productDetail.ProductHeight,
                    ProductWidth = productDetail.ProductWidth,
                    ProductWeight = productDetail.ProductWeight,
                    ProductDisplaySize = productDetail.ProductDisplaySize,
                    ProductDisplayType = productDetail.ProductDisplayType,
                    ProductResolution = productDetail.ProductResolution,
                    ProductProcessor = productDetail.ProductProcessor,
                    ProductOS = productDetail.ProductOS,
                    ProductMemoryRAM = productDetail.ProductMemoryRAM,
                    ProductMemoryROM = productDetail.ProductMemoryROM,
                    ProductRearCamera = productDetail.ProductRearCamera,
                    ProductFrontCamera = productDetail.ProductFrontCamera,
                    ProductBattery = productDetail.ProductBattery,
                    ProductRelDate = productDetail.ProductRelDate,
                };

                //return CreatedAtAction("GetProductDetail", new { id = productDetail.ProductDetailId }, productDetail);
                return CreatedAtAction("GetProductDetail", new { id = productDetailDto.ProductDetailId }, productDetailDto);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(int id)
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

            return NoContent();
        }

        private bool ProductDetailExists(int id)
        {
            return (_context.ProductDetails?.Any(e => e.ProductDetailId == id)).GetValueOrDefault();
        }
    }
}
