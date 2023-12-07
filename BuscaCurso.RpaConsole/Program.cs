using BuscaCurso.AluraWebDriver;
using BuscaCurso.Domain.Repositories;
using BuscaCurso.Domain.Services;
using BuscaCurso.InfraData.Context;
using BuscaCurso.InfraData.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BuscaCurso.RpaConsole
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var serviceColletion = new ServiceCollection();
			ConfigureServices(serviceColletion);
			var serviceProvider = serviceColletion.BuildServiceProvider();
			var cursoRepository = serviceProvider.GetService<ICursoRepository>();
			var aluraPagesService = serviceProvider.GetService<IAluraPagesServices>();
			var processo = new ProcessoAlura(cursoRepository, aluraPagesService);
			processo.BuscaCursoAlura();
		}

		public static void ConfigureServices(IServiceCollection services)
		{
			IConfiguration configuration = new ConfigurationBuilder()
		   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
		   .AddJsonFile("appsettings.json")
		   .Build();

			services.AddScoped<ICursoRepository, CursoRepository>();
			services.AddScoped<IAluraPagesServices, PagesServices>();
			services.AddSingleton(configuration)
			.AddDbContext<BuscaCursoContext>()
			.BuildServiceProvider();
		}
	}
}