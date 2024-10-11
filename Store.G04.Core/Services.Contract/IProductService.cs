using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Services.Contract
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDTO>> GetAllProductsAsync(string? sort);
		Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync();
		Task<IEnumerable<TypeBrandDTO>> GetAllBrandsAsync();
		
		Task<ProductDTO> GetProductById(int id);
	}
}
