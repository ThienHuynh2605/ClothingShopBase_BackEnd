
using AutoMapper;
using ClothingShop.Application.DTOs.ProductDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Core;
using ClothingShop.Core.Entities;
using ClothingShop.Infrastructure.IRepositories;


namespace ClothingShop.Application.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id )
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            var getProduct = _mapper.Map<ProductDto>(product);
            return getProduct;
        }

        public async Task<Pagination<ProductDto>> GetProductAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var (products, totalProduct) = await _productRepository.GetProductAsync(page, pageSize);
            var totalPage = (int)Math.Ceiling((decimal)totalProduct / pageSize);
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return new Pagination<ProductDto>
            {
                Total = totalProduct,
                TotalPages = totalPage,
                CurrentPage = page,
                PageSize = pageSize,
                Item = productDtos
            };
        }

        public async Task<bool> UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            return await _productRepository.UpdateProductAsync(id, product);
        }


        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            return await _productRepository.SoftDeleteProductAsync(id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

      

       
        public async Task<bool> RestoreProductAsync(int id)
        {
            return await _productRepository.RestoreProductAsync(id);
        }

        

      
    }
}
