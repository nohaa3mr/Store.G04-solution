using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.G04.Core;
using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Entities;
using Store.G04.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Service.Services.Products
{
	public class ProductSevice : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductSevice( IUnitOfWork unitOfWork , IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<IEnumerable<ProductDTO>> GellAllProductsAsync()
		=> _mapper.Map<IEnumerable<ProductDTO>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
		

		public async Task<IEnumerable<TypeBrandDTO>> GetAllBrandsAsync()
		{
	 	return _mapper.Map<IEnumerable<TypeBrandDTO>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());
		}

		public async Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync()
		{
			return _mapper.Map<IEnumerable<TypeBrandDTO>>(await _unitOfWork.Repository<ProductType,int>().GetAllAsync());

		}

		public async Task<ProductDTO> GetProductById(int id)
		{
		 var product=	await _unitOfWork.Repository<Product, int>().GetByIdAsync(id);
		var mapper = _mapper.Map<ProductDTO>(product);
			return mapper;

		}
	}
}
