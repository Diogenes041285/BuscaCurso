using BuscaCurso.Domain.Models;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace BuscaCurso.AluraWebDriver.Pages
{
	internal class BuscaPage : PageBase
	{
		private const string _XPATHTXTBUSCA = "//input[@id='busca-form-input']";
		private const string _XPATHBTNBUSCAR = "//input[@class='busca-form-botao --desktop']";
		private const string _LINHARESULTADO = "//li[@class='busca-resultado']";

		public bool TemCampoBusca()
		{
			return Aguardar(_XPATHTXTBUSCA, 20);				
		}

		public List<Curso> BuscarCursoPorNome(string nome)
		{
			List<Curso> cursos = null;
			_driver.Navigate().GoToUrl("https://www.alura.com.br/busca");
			AguardarElementosPrincipais();
			_driver.FindElement(By.XPath(_XPATHTXTBUSCA)).SendKeys(nome);
			_driver.FindElement(By.XPath(_XPATHBTNBUSCAR)).Click();			
			if (!Aguardar(_LINHARESULTADO, 30))
				return cursos;

			var linkPaginas = _driver.FindElements(By.XPath("//a[contains(@class,'paginationLink')]"));
			cursos = new List<Curso>();

			for (int i = 1; i <= linkPaginas.Count; i++)
			{
				if (i > 1)
				{
					linkPaginas[i-1].Click();
					if (!Aguardar(_LINHARESULTADO, 30))
						continue;
				}

				foreach (var linha in _driver.FindElements(By.XPath(_LINHARESULTADO)))
				{
					Curso curso = new Curso();
					curso.Titulo = linha.FindElement(By.XPath("./descendant::h4[@class='busca-resultado-nome']")).Text;
					curso.Descricao = linha.FindElement(By.XPath("./descendant::p[@class='busca-resultado-descricao']")).Text;
					curso.Link = linha.FindElement(By.XPath("./descendant::a[@class='busca-resultado-link']")).GetAttribute("href");
					cursos.Add(curso);
				}
			}
			BuscarInformacoesComplementares(cursos);

			return cursos;
		}
				
		private void AguardarElementosPrincipais()
		{
			if (!Aguardar(_XPATHTXTBUSCA, 20))
				throw new NoSuchElementException("Textbox de busca não encontrado!");

			if (!Aguardar(_XPATHBTNBUSCAR, 20))
				throw new NoSuchElementException("Botão de busca não encontrado!");
		}

		private void BuscarInformacoesComplementares(List<Curso> cursos)
		{
			foreach (var curso in cursos)
			{
				if (string.IsNullOrEmpty(curso.Link))
					continue;

				_driver.Navigate().GoToUrl(curso.Link);
				if (Aguardar("//div[@class='formacao__info-destaque']", 5))
				{
					string cargaHoraria = _driver.FindElement(By.XPath("//div[@class='formacao__info-destaque']")).Text;
					if(!string.IsNullOrEmpty(cargaHoraria))
						curso.CargaHoraria = Convert.ToInt32(Regex.Match(cargaHoraria, @"\d+").Value);
				}

				if (Aguardar("//h3[@class='instructor-title--name']", 5))
					curso.Professor = _driver.FindElement(By.XPath("//h3[@class='instructor-title--name']")).Text;					
				
			}
		}
	}
}
