using Microsoft.AspNetCore.Mvc;
using Store.G04.APIs.Errors;
using Store.G04.Repositories.Data.Contexts;

namespace Store.G04.APIs.Controllers
{
	public class BuggyController : ControllerBase
	{
		private readonly StoreDbContext _context;

		public BuggyController(StoreDbContext context)
        {
		    _context = context;
		}
        [HttpGet("Notfound")]
		public IActionResult GetNotFoundError()
		{
			var product = _context.products.Find(100);
			if (product is null) return NotFound(new APIsResponseError(404));
			return Ok(product);
		}
		[HttpGet("ServerError")]
		public IActionResult ServerError()
		{
			var product = _context.products.Find(100);
			var result = product.ToString();
			return Ok(result);
		}
		[HttpGet("BadRequest")]
		public ActionResult GetBadRequestError()
		{
			return BadRequest();
		}

		[HttpGet("BadRequest/{id}")]
		public ActionResult GetBadRequestError(int id)
		{
			return Ok();
		}
	}
}
