using AutoMapper;
using ClothingShop.Application.DTOs;
using ClothingShop.Application.DTOs.ProductDtos;
using ClothingShop.Application.IServices;
using ClothingShop.Core;
using ClothingShop.Core.Entities;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Repositories;



namespace ClothingShop.Application.Services
{
    public class ProductVariantService : IProductVariantService
    {
        public readonly IProductVariantRepository _productVariantRepository;
        public readonly IMapper _mapper;
        public ProductVariantService(IProductVariantRepository productVariantRepository, IMapper mapper)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductVariantAsync(ProductVariantDto productVariantDto)
        {
            var productVariant = _mapper.Map<ProductVariant>(productVariantDto);
            return await _productVariantRepository.CreateProductVariantAsync(productVariant);
        }

        public async Task<ProductVariantDto> GetProductVariantByIdAsync(int id)
        {
            var productVariant = await _productVariantRepository.GetProductVariantByIdAsync(id);
            var getProductVariant = _mapper.Map<ProductVariantDto>(productVariant);
            return getProductVariant;
        }

        public async Task<Pagination<ProductVariantDto>> GetProductVariantAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var (productVariants, totalProductVariant) = await _productVariantRepository.GetProductVariantAsync(page, pageSize);
            var totalPage = (int)Math.Ceiling((decimal)totalProductVariant / pageSize);
            var productVariantDtos = _mapper.Map<List<ProductVariantDto>>(productVariants);

            return new Pagination<ProductVariantDto>
            {
                Total = totalProductVariant,
                TotalPages = totalPage,
                CurrentPage = page,
                PageSize = pageSize,
                Item = productVariantDtos
            };
        }

        public async Task<bool> UpdateProductVariantAsync(int id, ProductVariantDto productVariantDto)
        {
            var productVariant = _mapper.Map<ProductVariant>(productVariantDto);
            return await _productVariantRepository.UpdateProductVariantAsync(id, productVariant);
        }
        public async Task<bool> SoftDeleteProductVariantAsync(int id)
        {
            return await _productVariantRepository.SoftDeleteProductVariantAsync(id);
        }

        public async Task<bool> RestoreProductVariantAsync(int id)
        {
            return await _productVariantRepository.RestoreProductVariantAsync(id);


        }

        public async Task<bool> DeleteProductVariantAsync(int id)
        {
            return await _productVariantRepository.DeleteProductVariantAsync(id);

        }







    }
}
