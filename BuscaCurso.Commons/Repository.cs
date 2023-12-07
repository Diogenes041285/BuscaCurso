using BuscaCurso.Commons.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BuscaCurso.Commons
{
	public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class
	{
		protected readonly DbContext Db;
		protected readonly DbSet<TEntity> DbSet;

		public Repository(DbContext context)
		{
			Db = context;
			DbSet = Db.Set<TEntity>();
		}

		public virtual void Add(TEntity obj) =>
			DbSet.Add(obj);

		public void AddRange(List<TEntity> obj) =>
			DbSet.AddRange(obj);

		public virtual TEntity GetById(TID id) => DbSet.Find(id);

		public virtual IQueryable<TEntity> GetAll() => DbSet;

		public virtual IQueryable<TEntity> GetPagination(
			Expression<Func<TEntity, bool>> filter,
			int page = 1,
			int quantity = 10) =>
			DbSet.Where(filter).Skip((page - 1) * quantity).Take(quantity);

		public virtual IQueryable<TEntity> GetPagination(
		  Expression<Func<TEntity, bool>> filter,
		  Expression<Func<TEntity, object>> orderBy,
		  int page = 1,
		  int quantity = 10
		  ) =>
		  DbSet.Where(filter).Skip((page - 1) * quantity).Take(quantity);

		public virtual IQueryable<TEntity> GetAutoComplete(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, object>> orderBy,
			int quantity = 10) =>
			DbSet.Where(filter).OrderBy(orderBy).Take(quantity);

		public virtual void Update(TEntity obj) =>
			DbSet.Update(obj);

		public virtual void Remove(TID id) =>
			DbSet.Remove(DbSet.Find(id));

		public virtual void RemoveRange(IQueryable<TEntity> entities) =>
			Db.RemoveRange(entities);

		public int SaveChanges() =>
			Db.SaveChanges();

		public void Dispose()
		{
			Db.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
