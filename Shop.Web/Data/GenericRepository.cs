

namespace Shop.Web.Data
{
	
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using Entities;
	public class GenericRepository<T> : IGenericRepository<T> where T : class,IEntity
    {
		private readonly DataContext context;
		private readonly DataContext dataContext;

		public GenericRepository(DataContext context, DataContext dataContext)
		{
			this.context = context;
			this.dataContext = dataContext;
		}

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        public IQueryable<T> GetAll()
		{
			//ASNOTRAKING para que funcione el metodo Generico
			return this.context.Set<T>().AsNoTracking();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await this.context.Set<T>()
				.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task CreateAsync(T entity)
		{
			await this.context.Set<T>().AddAsync(entity);
			await SaveAllAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			this.context.Set<T>().Update(entity);
			await SaveAllAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			this.context.Set<T>().Remove(entity);
			await SaveAllAsync();
		}

		public async Task<bool> ExistAsync(int id)
		{
			return await this.context.Set<T>().AnyAsync(e => e.Id == id);

		}

		public async Task<bool> SaveAllAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}
	}
}
