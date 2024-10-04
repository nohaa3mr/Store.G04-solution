using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Services.Contract
{
	public interface IProductService
	{
		Task<IEnumerable<ProductDTO>> GellAllProductsAsync();
		Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync();
		Task<IEnumerable<TypeBrandDTO>> GetAllBrandsAsync();
		
		Task<ProductDTO> GetProductById(int id);
	}
}
