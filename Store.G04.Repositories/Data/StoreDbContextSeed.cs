using Microsoft.EntityFrameworkCore;
using Store.G04.Core.Entities;
using Store.G04.Repositories.Data.Contexts;
using System.Text.Json;


namespace Store.G04.Repositories.Data
{
	public static class StoreDbContextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context)
		{
		
				//1.Read All Data From Json File.
				var BrandData = File.ReadAllText(@"..\Store.G04.Repositories\Data\SeedData\brands.json");
				//2. Convert Data from Json to List<T>
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
				//3.Seed DataBase
				if (brands is not null && brands.Count > 0)
		    	{

					await _context.brands.AddRangeAsync(brands);
					await _context.SaveChangesAsync(); 
				}
			    
			
				//1.Read All Data From Json File.
				var TypeData = File.ReadAllText(@"..\Store.G04.Repositories\Data\SeedData\types.json");
				//2. Convert Data from Json to List<T>
				var types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);
				//3.Seed DataBase
				if (types is not null && types.Count > 0)
				{
				
					await _context.types.AddRangeAsync(types);
					await _context.SaveChangesAsync(); 
				
				}
			
			
				//1.Read All Data From Json File.
				var ProductData = File.ReadAllText(@"..\Store.G04.Repositories\Data\SeedData\products.json");


				//2. Convert Data from Json to List<T>
				var products = JsonSerializer.Deserialize<List<Product>>(ProductData);
				//3.Seed DataBase
				if ( products is not null  && products?.Count > 0)
				{ 
					await _context.AddRangeAsync(products);
					await _context.SaveChangesAsync();
		      	}

		}
	}
}
