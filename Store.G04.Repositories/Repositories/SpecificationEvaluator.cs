using Store.G04.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Store.G04.Core.Entities;

namespace Store.G04.Repositories.Repositories
{
	public static class SpecificationEvaluator<T> where T : BaseEntity
	{
		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> specifications)
		{
			var Query = inputQuery;
			if (specifications.Critiria is not null)
			{
				Query = Query.Where(specifications.Critiria);
			}
			if(specifications.OrderBy is not null)
			{
				Query = Query.OrderBy(specifications.OrderBy);
			}
			if (specifications.OrderByDescending is not null)
			{
				Query = Query.OrderByDescending(specifications.OrderByDescending);
			}
			Query = specifications.Includes.Aggregate(Query, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
			return Query;
			
		}

	}
}
