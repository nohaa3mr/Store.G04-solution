using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Specifications;

namespace Store.G04.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly IGenericRepository<Product> _productrepo;
		private readonly IGenericRepository<ProductBrand> _brandrepo;
		private readonly IGenericRepository<ProductType> _typerepo;

		public ProductController(  IMapper mapper , 
			IGenericRepository<Product> productrepo ,
			IGenericRepository<ProductBrand> brandrepo, 
			IGenericRepository<ProductType> typerepo)
        {
			this.mapper = mapper;
			_productrepo = productrepo;
			_brandrepo = brandrepo;
			_typerepo = typerepo;
		}


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] ProductsSpecParameters parameters) //endpoint
		{

			var Spec = new ProductSpecifications(parameters );
			var Result = await _productrepo.GetAllWithSpec(Spec);
			var mappedproducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(Result);
				
			return Ok(mappedproducts);

		}

		[HttpGet("brands")]
		public async Task<IActionResult> GetAllBrands()
		{
			var results = await _brandrepo.GetAllAsync();

			var mapped = mapper.Map<ProductDTO>(results);
			return Ok(mapped);
		}

		[HttpGet("types")] //change the segment
		public async Task<IActionResult> GetAllTypes()
		{
			var Result = await _typerepo.GetAllAsync();
			var mapped = mapper.Map<ProductDTO>(Result);
			return Ok(mapped);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProductsByIdwithSpecification(int id)
		{
			var spec = new ProductSpecifications(id); 
			var results = await _productrepo.GetByIdWithSpecAsync(spec);
			if (results is null) return NotFound(new APIsResponseError(404));
			var mapped = mapper.Map<ProductDTO>(results);
			return Ok(mapped);
		}
	}	

	
}
