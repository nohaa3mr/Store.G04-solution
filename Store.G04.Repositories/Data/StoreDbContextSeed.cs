using Store.G04.Core.Entities;
using Store.G04.Repositories.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.G04.Repositories.Data
{
	public static class StoreDbContextSeed
	{
		public async static Task SeedAsync(StoreDbContext _context)
		{
			if (_context.brands.Count() == 0)
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
			}

			if (_context.types.Count() == 0)
			{
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
			}
			if (_context.products.Count() == 0)
			{
				//1.Read All Data From Json File.
				var ProductData = File.ReadAllText(@"..\Store.G04.Repositories\Data\SeedData\products.json");


				//2. Convert Data from Json to List<T>
				var product = JsonSerializer.Deserialize<List<Product>>(ProductData);
				//3.Seed DataBase
				if (product is not null && product.Count() > 0)
				{
					await _context.products.AddRangeAsync(product);
					await _context.SaveChangesAsync();
				}
			}
		}
	}
}
