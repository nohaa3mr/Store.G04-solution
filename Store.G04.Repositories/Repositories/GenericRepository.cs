using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Store.G04.Core.Entities;
using Store.G04.Core.Repositories.Contract;
using Store.G04.Core.Specifications;
using Store.G04.Repositories.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repositories.Repositories
{
	public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity ,Tkey> where TEntity : BaseEntity<Tkey>
	{
		private readonly StoreDbContext _context;

		public GenericRepository(StoreDbContext context) 
        {
			_context = context;
		}
        public async Task AddAsync(TEntity entity)
		{
		  await	_context.AddAsync(entity);
		}

		public void Delete(TEntity entity)
		{
			_context.Remove(entity);

		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			if (typeof(TEntity) == typeof(Product))
			{
				return(IEnumerable<TEntity>) await _context.products.OrderBy( N=> N.Name).Include(p => p.Brand).Include(P => P.Type).ToListAsync();
			}
		     return	await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAllWithSpec(ISpecifications<TEntity> spec)
		{
			return await ApplySpecifications(spec).ToListAsync();
		}



		public async Task<TEntity> GetByIdAsync(Tkey id)
		{
			if (typeof(TEntity) == typeof(Product))
			{
				return await _context.products.Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync(p => p.Id == id as int?) as TEntity;

			}
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> GetByIdWithSpecAsync(ISpecifications<TEntity> spec)
		{
			return await ApplySpecifications(spec).FirstOrDefaultAsync();
		}

		

		public void Update(TEntity entity)
		{
			_context.Update(entity);	
	    }

		private IQueryable<TEntity> ApplySpecifications(ISpecifications<TEntity> specifications)
		{
			 return  SpecificationEvaluator<TEntity, Tkey>.GetQuery(_context.Set<TEntity>(), specifications);
		}
	}
}
