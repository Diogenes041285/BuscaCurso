using BuscaCurso.AluraWebDriver.Pages;
using BuscaCurso.Domain.Models;
using BuscaCurso.Domain.Services;

namespace BuscaCurso.AluraWebDriver
{
	public class PagesServices : IAluraPagesServices
	{
		private BuscaPage _buscaPage;

        public PagesServices()
        {
			_buscaPage = new BuscaPage();
        }

        public List<Curso> BuscarCursosPorNome(string nome)
		{ 
			return _buscaPage.BuscarCursoPorNome(nome);
		}
	}
}
