using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repositories.Data.ClassConfigurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.PictureURL).IsRequired();
			builder.Property(p => p.Name).IsRequired();
			builder.Property(p => p.Description).IsRequired();

			builder.HasOne(P => P.Brand).WithMany().HasForeignKey(P => P.BrandId);

			builder.HasOne(P => P.Type).WithMany().HasForeignKey(P => P.TypeId);
		}
	}
}
