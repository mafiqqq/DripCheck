using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DripCheckAPI.Models;
using DripCheckAPI.Models.DTO;

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

            var productDetails = await _context.ProductDetails.ToListAsync();

            var productDetailsDto = productDetails.Select(productDetail => new ProductDetailDto()
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
                ProductRelDate = productDetail.ProductBattery,
            }).ToList();

            //return await _context.ProductDetails.ToListAsync();
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

        // POST: api/ProductDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        public async Task<ActionResult<ProductDetail>> PostProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            if (_context.ProductDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductDetails'  is null.");
            }
            
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
                ProductRelDate = createProductDetailDto.ProductRelDate
            };

            _context.ProductDetails.Add(productDetail);
            await _context.SaveChangesAsync();

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


            //_context.ProductDetails.Add(productDetail);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProductDetail", new { id = productDetail.ProductDetailId }, productDetail);
            return CreatedAtAction("GetProductDetail", new { id = productDetailDto.ProductDetailId }, productDetailDto);

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
