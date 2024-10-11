using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Services.Contract;
using Store.G04.Core.Specifications;

namespace Store.G04.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper mapper;

		public ProductController(  IProductService productService , IMapper mapper)
        {
			_productService = productService;
			this.mapper = mapper;
		
		}


		[HttpGet]
		public async Task<IActionResult> GetAllProductsWithSpec(string sort) //endpoint
		{

			var Spec = new ProductSpecifications(sort);
			var Result = await _productService.GetAllProductsAsync(sort);
			if (Result is null)
		return NotFound(new APIsResponseError(404));
			var mapped = mapper.Map<ProductDTO>(Result);

			return Ok(Result);
		}

		[HttpGet("brands")]
		public async Task<IActionResult> GetAllBrands()
		{
			var results = await _productService.GetAllBrandsAsync();
			return Ok(results);
		}

		[HttpGet("types")] //change the segment
		public async Task<IActionResult> GetAllTypes()
		{
			var Result = await _productService.GetAllTypesAsync();
			return Ok(Result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProductsByIdwithSpecification(int id)
		{
			var spec = new ProductSpecifications(id); 
			var results = await _productService.GetProductById(id);
			if (results is null) return NotFound(new APIsResponseError(404));
			return Ok(results);
		}
	}	

	
}
