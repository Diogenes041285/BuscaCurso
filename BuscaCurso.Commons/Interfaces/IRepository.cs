using System.Linq.Expressions;

namespace BuscaCurso.Commons.Interfaces
{
	public interface IRepository<TEntity, TID> : IDisposable where TEntity : class
	{
		void Add(TEntity obj);
		void AddRange(List<TEntity> obj);

		TEntity GetById(TID id);

		IQueryable<TEntity> GetAll();

		IQueryable<TEntity> GetPagination(
			Expression<Func<TEntity, bool>> filter, int pagina = 1, int qtdRegistros = 10);

		IQueryable<TEntity> GetPagination(
			Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, int pagina = 1, int qtdRegistros = 10);

		IQueryable<TEntity> GetAutoComplete(
			Expression<Func<TEntity, bool>> filter,
			Expression<Func<TEntity, object>> orderBy,
			int quantity = 10);

		void Update(TEntity obj);

		void Remove(TID id);

		void RemoveRange(IQueryable<TEntity> predicate);

		int SaveChanges();
	}
}
