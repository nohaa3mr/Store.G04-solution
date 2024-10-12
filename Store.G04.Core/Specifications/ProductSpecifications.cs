using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
	public class ProductSpecifications : Specifications<Product>
	{
	
        public ProductSpecifications(ProductsSpecParameters parameters) : base(P =>
			 (!parameters.BarandId.HasValue || parameters.BarandId == P.BrandId)
			 &&
			 (!parameters.TypeId.HasValue || parameters.TypeId == P.TypeId)
			 )

		{
            if (string.IsNullOrEmpty(parameters.Sort))
            {
                switch (parameters.Sort)
                {
                    case "PriceAsc":
                      AddOrderBy(P => P.Price);
                        break;
                    case "PriceDecs":
                        AddOrderBy(P => P.Price);
                        break;
                    default :
        
                        OrderBy = P => P.Name;
                        break;

                }

            }
          
            
			Includes.Add(P => P.Type);
			Includes.Add(P => P.Brand);
		}
		public ProductSpecifications(int id) : base(P => P.Id == id)
		{
			Includes.Add(P => P.Type);
			Includes.Add(P => P.Brand);
		}
	}
}
