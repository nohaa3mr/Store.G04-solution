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
		public ProductSpecifications(int id): base() 
        {
            Includes.Add(P => P.Type);
            Includes.Add(P => P.Brand);
        }
        public ProductSpecifications( string? sort ) :base()
             //P =>
             //(!brandId.HasValue || brandId ==P.BrandId)
             //&& 
             //(!typeId.HasValue || typeId == P.TypeId)
            
        {
            if (string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
    }
}
