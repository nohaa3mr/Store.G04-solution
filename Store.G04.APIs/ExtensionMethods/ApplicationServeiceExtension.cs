using Microsoft.AspNetCore.Mvc;
using Store.G04.Core.Entities;
using Store.G04.Core.Profiles;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Services.Contract;
using Store.G04.Core;
using Store.G04.Repositories.Repositories;
using Store.G04.Repositories;
using Store.G04.Service.Services.Products;
using Store.G04.APIs.Errors;
using Store.G04.Core.DTOs.Products.DTOs;

namespace Store.G04.APIs.ExtensionMethods
{
	public static class ApplicationServeiceExtension
	{
		public static IServiceCollection ApplicationServer(this IServiceCollection Services)
		{
		   Services.AddScoped<IProductService, ProductSevice>();
			Services.AddScoped<IUnitOfWork, UnitOfWork>();
			Services.AddScoped< IGenericRepository <Product,int>, GenericRepository<Product, int>>();
			Services.AddAutoMapper(typeof(ProductDTO));

			Services.Configure<ApiBehaviorOptions>(Options =>
			{
				Options.InvalidModelStateResponseFactory = (actioncontext) =>
				{
					var errors = actioncontext.ModelState.Where(P => P.Value.Errors.Count() > 0)
													   .SelectMany(P => P.Value.Errors).Select(E => E.ErrorMessage).ToList();

					var ValidationError = new ApisValidationError()
					{
						Errors = errors
					};
					return new BadRequestObjectResult(ValidationError);
				};
			});
			return Services;
		}
	}
}
