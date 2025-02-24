using AutoMapper;
using ClothingShop.Application.DTOs;
using ClothingShop.Application.IServices;
using ClothingShop.Core.Entities;
using ClothingShop.Core.IRepositories;

namespace ClothingShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsyn(ProductDto input)
        {
            var product = _mapper.Map<Product>(input);
            await _productRepository.CreateProductAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }
    }
}
