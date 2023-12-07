using BuscaCurso.Domain.Models;

namespace BuscaCurso.Domain.Services
{
	public interface IAluraPagesServices
	{
		List<Curso> BuscarCursosPorNome(string nome);
	}
}
