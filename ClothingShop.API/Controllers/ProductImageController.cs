using AutoMapper;
using ClothingShop.Application.DTOs;
using ClothingShop.Application.IServices;
using ClothingShop.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingShop.API.Controllers
{
    [Route("api/product/image")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        public readonly IProductImageService _productImageService;
        public readonly IMapper _mapper;
        public ProductImageController(IProductImageService productImageService, IMapper mapper)
        {
            _productImageService = productImageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImageAsync(ProductImageDto productImageDto)
        {
            var result = await _productImageService.CreateProductImageAsync(productImageDto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByIdAsync(int id)
        {
            var productImage = await _productImageService.GetProductImageByIdAsync(id);
            return Ok(productImage);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImageAsync(int page = 1, int pageSize = 5)
        {
            var productImage = await _productImageService.GetProductImageAsync(page, pageSize);
            return Ok(productImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductImageAsync(int id, [FromBody] ProductImageDto productImageDto)
        {
            var result = await _productImageService.UpdateProductImageAsync(id, productImageDto);
            return Ok(result);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteProductImageAsync(int id)
        {
            var result = await _productImageService.SoftDeleteProductImageAsync(id);
            return Ok(result);
        }

        [HttpPost("restore/{id}")]
        public async Task<IActionResult> RestoreProductImageAsync(int id)
        {
            var result = await _productImageService.RestoreProductImageAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImageAsync(int id)
        {
            var result = await _productImageService.DeleteProductImageAsync(id);
            return Ok(result);
        }
    }
}
