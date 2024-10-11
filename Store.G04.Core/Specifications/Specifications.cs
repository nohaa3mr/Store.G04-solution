using Store.G04.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Specifications
{
	public class Specifications<T> : ISpecifications<T> 
	{
        public Specifications()
        {
            
        }
        public Specifications(Expression<Func<T, bool>> expression)
        {
            Critiria = expression;
        }
        public Expression<Func<T, bool>> Critiria { get; set; }
		public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderByDescending { get; set; } 
        public Expression<Func<T, object>> OrderBy { get; set; } 
        public void AddOrderBy(Expression<Func<T,object>> expression)
        {
            OrderBy = expression;
        }
        public void AddOrderByDescending(Expression<Func<T,object>> expression)
        {
            OrderByDescending = expression;
        }
	}
}
