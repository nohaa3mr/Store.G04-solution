﻿ using Store.G04.Core.Entities;
using Store.G04.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repositories.Contract
{
 public interface IGenericRepository<T, Tkey> where T : BaseEntity<Tkey>
 {
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(Tkey id); 
		Task AddAsync(T entity);
		void Delete(T entity);
		void Update(T entity);

		Task<IEnumerable<T>> GetAllWithSpec(ISpecifications<T> specifications);
		Task<T> GetByIdWithSpecAsync(ISpecifications<T> spec);
  }
}
