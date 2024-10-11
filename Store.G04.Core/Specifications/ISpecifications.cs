using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
	public interface ISpecifications<T> 
	{
        public Expression<Func<T,bool>> Critiria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
		public Expression<Func<T, object>> OrderByDescending { get; set; }
		public Expression<Func<T, object>> OrderBy   { get; set; }


    }
}
