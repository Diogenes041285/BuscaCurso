using BuscaCurso.Commons;
using BuscaCurso.Domain.Models;
using BuscaCurso.Domain.Repositories;
using BuscaCurso.InfraData.Context;

namespace BuscaCurso.InfraData.Repositories
{
	public class CursoRepository : Repository<Curso, int>, ICursoRepository
	{
		public BuscaCursoContext DbAll { get; }

		public CursoRepository(BuscaCursoContext context) : base(context)
		{
			DbAll = context;
		}
	}
}
