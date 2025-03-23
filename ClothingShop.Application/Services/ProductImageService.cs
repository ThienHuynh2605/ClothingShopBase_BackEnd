using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClothingShop.Application.DTOs;
using ClothingShop.Application.IServices;
using ClothingShop.Core;
using ClothingShop.Core.Entities;
using ClothingShop.Infrastructure.IRepositories;
using ClothingShop.Infrastructure.Repositories;

namespace ClothingShop.Application.Services
{
    public class ProductImageService : IProductImageService
    {
        public readonly IProductImageRepository _productImageRepository;
        public readonly IMapper _mapper;
        public ProductImageService(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductImageAsync(ProductImageDto productImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            return await _productImageRepository.CreateProductImageAsync(productImage);
        }

        public async Task<ProductImageDto> GetProductImageByIdAsync(int id)
        {
            var productImage = await _productImageRepository.GetProductImageByIdAsync(id);
            var getProductImage = _mapper.Map<ProductImageDto>(productImage);
            return getProductImage;
        }

        public async Task<Pagination<ProductImageDto>> GetProductImageAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var (productImages, totalProductImage) = await _productImageRepository.GetProductImageAsync(page, pageSize);
            var totalPage = (int)Math.Ceiling((decimal)totalProductImage / pageSize);
            var productImageDtos = _mapper.Map<List<ProductImageDto>>(productImages);

            return new Pagination<ProductImageDto>
            {
                Total = totalProductImage,
                TotalPages = totalPage,
                CurrentPage = page,
                PageSize = pageSize,
                Item = productImageDtos
            };
        }

        public async Task<bool> UpdateProductImageAsync(int id, ProductImageDto productImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            return await _productImageRepository.UpdateProductImageAsync(id, productImage);
        }

        public async Task<bool> SoftDeleteProductImageAsync(int id)
        {
           return await _productImageRepository.SoftDeleteProductImageAsync(id);
        }

        public async Task<bool> RestoreProductImageAsync(int id)
        {
            return await _productImageRepository.RestoreProductImageAsync(id);
        }

        public async Task<bool> DeleteProductImageAsync(int id)
        {
            return await _productImageRepository.DeleteProductImageAsync(id);

        }






    }
}
