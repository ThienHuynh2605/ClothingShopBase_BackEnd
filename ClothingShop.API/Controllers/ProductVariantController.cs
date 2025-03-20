using ClothingShop.Application.DTOs;
using ClothingShop.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductVariantController: ControllerBase
    {
        public readonly IProductVariantService _productVariantService;
        public ProductVariantController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductVariantAsync(ProductVariantDto productVariantDto)
        {
            var result = await _productVariantService.CreateProductVariantAsync(productVariantDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductVariantByIdAsync(int id)
        {
            var productVariant = await _productVariantService.GetProductVariantByIdAsync(id);
            return Ok(productVariant);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductVariantAsync(int page = 1, int pageSize = 5)
        {
            var productVariant = await _productVariantService.GetProductVariantAsync(page, pageSize);
            return Ok(productVariant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductVariantAsync(int id, [FromBody] ProductVariantDto productVariantDto)
        {
            var result = await _productVariantService.UpdateProductVariantAsync(id, productVariantDto);
            return Ok(result);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteProductVariantAsync(int id)
        {
            var result = await _productVariantService.SoftDeleteProductVariantAsync(id);
            return Ok(result);
        }

        [HttpPost("restore/{id}")]
        public async Task<IActionResult> RestoreProductVariantAsync(int id)
        {
            var result = await _productVariantService.RestoreProductVariantAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductVariantAsync(int id)
        {
            var result = await _productVariantService.DeleteProductVariantAsync(id);
            return Ok(result);
        }

    }
}
 