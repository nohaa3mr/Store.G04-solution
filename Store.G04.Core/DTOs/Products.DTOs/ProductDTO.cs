using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.DTOs.Products.DTOs
{
	public class ProductDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
		public string? PictureURL { get; set; }
		public decimal Price { get; set; }
		public string BrandName { get; set; }
		public int? BrandId { get; set; }

		public string TypeName { get; set; }
		public int? TypeId { get; set; }
	}
}
