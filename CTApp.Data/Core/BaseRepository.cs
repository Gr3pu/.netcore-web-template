using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CTApp.Data.Core
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetByExpressions(params Expression[] expressions);
		ICollection<T> GetAll();
		ValueTask<T> GetOne(int id);
		ValueTask<T> GetOne(Guid hash);

		ValueTask<T> Add(T model);
		T Update(T model);

		ValueTask<T> Archive(Guid hash);
	}

	public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		private readonly ApplicationDbContext _context;

		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public abstract IQueryable<T> GetByExpressions(params Expression[] expressions);
		public abstract ICollection<T> GetAll();

		public async ValueTask<T> GetOne(int id)
		{
			var entity = _context.FindAsync<T>(id);
			return await entity;
		}

		public async ValueTask<T> GetOne(Guid hash)
		{
			var entity = _context.FindAsync<T>(hash);
			return await entity;
		}



		public async ValueTask<T> Add(T model)
		{
			var entity = model;
			var today = DateTime.Now;

			entity.Id = 0;
			entity.UpdatedAt = today;

			await _context.AddAsync<T>(entity);

			return entity;
		}

		public T Update(T model)
		{
			var entity = model;
			var today = DateTime.Now;

			model.UpdatedAt = today;
			_context.Update<T>(entity);

			return entity;
		}

		public async ValueTask<T> Archive(Guid hash)
		{
			var entity = await this.GetOne(hash);
			var today = DateTime.Now;

			entity.UpdatedAt = today;
			entity.ArchivedAt = today;
			entity.IsArchived = true;

			return this.Update(entity);
		}
	}
}
