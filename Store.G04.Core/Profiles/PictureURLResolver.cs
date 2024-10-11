using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.G04.Core.DTOs.Products.DTOs;
using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Profiles
{
	internal class PictureURLResolver : IValueResolver<Product, ProductDTO, string>
	{
		private readonly IConfiguration _configuration;

		public PictureURLResolver(IConfiguration configuration)
        {
			_configuration = configuration;
		}
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
		{
			if (string.IsNullOrEmpty(source.PictureURL))
			{
				return $"{_configuration["BASEURL"]}{source.PictureURL}";
			}
			return string.Empty;
		}
	}
}
