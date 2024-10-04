using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Services.Contract;

namespace Store.G04.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _product;

		public ProductController(IProductService product)
        {
			_product = product;
		}


		[HttpGet]
		public async Task<IActionResult> GetAllProduct() //endpoint
		{


			var Result = await _product.GellAllProductsAsync();
			return Ok(Result);
		}

		[HttpGet("brands")]
		public async Task<IActionResult> GetAllBrands()
		{
			var Results = await _product.GetAllBrandsAsync();
			return Ok(Results);
		}

		[HttpGet("types")] //change the segment
		public async Task<IActionResult> GetAllTypes()
		{
		    var Result=	await _product.GetAllTypesAsync();
			return Ok(Result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductsByIdAsync(int id)
		{
			var results = await _product.GetProductById(id);
			
			return Ok(results);
		}
	}	

	
}
