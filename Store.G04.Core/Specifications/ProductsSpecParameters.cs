using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
	public class ProductsSpecParameters 
	{
        public string Sort { get; set; }
        public int? BarandId { get; set; }
        public int? TypeId { get; set; }

        private int pageSize = 5;

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > 10 ? 10 : value;
            }
        }


    }
}
