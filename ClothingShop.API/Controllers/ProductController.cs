using ClothingShop.Application.DTOs.ProductDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(ProductDto productDto)
        {
            var result = await _productService.CreateProductAsync(productDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAsync(int page = 1, int pageSize = 5)
        {
            var product = await _productService.GetProductAsync(page, pageSize);
            return Ok(product);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] ProductDto productDto)
        //{
        //    var result = await _productService.UpdateProductAsync(id, productDto);
        //    return Ok(result);
        //}

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteProductAsync(int id)
        {
            var result = await _productService.SoftDeleteProductAsync(id);
            return Ok(result);
        }

        [HttpPost("restore/{id}")]
        public async Task<IActionResult> RestoreProductAsync(int id)
        {
            var result = await _productService.RestoreProductAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return Ok(result);
        }
    }
}
