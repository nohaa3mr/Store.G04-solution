using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core
{
	public interface IUnitOfWork
	{ 
		 Task<int> CompleteAsync();
		//To create specific repo from specific class
		IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
	}
}
