﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repositories.Data.ClassConfigurations
{
	public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
	{
		public void Configure(EntityTypeBuilder<ProductType> builder)
		{
			builder.Property(T => T.Name).IsRequired();

		}
	}
}
