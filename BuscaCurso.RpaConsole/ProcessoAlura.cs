using BuscaCurso.Domain.Repositories;
using BuscaCurso.Domain.Services;

namespace BuscaCurso.RpaConsole
{
	internal class ProcessoAlura
	{
		private readonly ICursoRepository _cursoRepository;
		private readonly IAluraPagesServices _aluraPagesServices;

		public ProcessoAlura(ICursoRepository cursoRepository, IAluraPagesServices aluraPagesServices)
		{
			_cursoRepository = cursoRepository;
			_aluraPagesServices = aluraPagesServices;
		}

		public void BuscaCursoAlura()
		{
			var listaCursos = _aluraPagesServices.BuscarCursosPorNome("rpa");
			if (listaCursos == null)
			{
				Console.WriteLine("Sem resultados para o termo buscado.");
				return;
			}

			_cursoRepository.AddRange(listaCursos);
			_cursoRepository.SaveChanges();
		}
	}
}
