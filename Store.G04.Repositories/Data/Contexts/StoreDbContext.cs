using Microsoft.EntityFrameworkCore;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repositories.Data.Contexts
{
	public class StoreDbContext :DbContext
	{
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options)
        {
            
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> brands { get; set; }
        public DbSet<ProductType> types { get; set; }
    }
}
