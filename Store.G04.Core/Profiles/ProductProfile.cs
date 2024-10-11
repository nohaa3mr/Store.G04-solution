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
	public class ProductProfile : Profile
	{
        public ProductProfile(IConfiguration configuration)
        {
            CreateMap<Product,ProductDTO>()
				.ForMember(D => D.BrandName , options => options.MapFrom(d=>d.Brand.Name) )
				.ForMember(T => T.TypeName, options => options.MapFrom(t => t.Type.Name))
			    .ForMember(s => s.PictureURL, options => options.MapFrom(new PictureURLResolver(configuration)));

			CreateMap<ProductBrand,TypeBrandDTO>().ReverseMap();
			CreateMap<ProductType,TypeBrandDTO>().ReverseMap();

		}
	}
}
