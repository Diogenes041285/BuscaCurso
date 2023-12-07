using BuscaCurso.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BuscaCurso.InfraData.Context
{
	public class BuscaCursoContext :  DbContext
	{
		private readonly IConfiguration _configuration;
		const string DBSCHEMA = "BuscaCurso";

		public BuscaCursoContext(DbContextOptions<BuscaCursoContext> options, IConfiguration configuration) : base(options)
		{
			_configuration = configuration;
		}

		public DbSet<Curso> Campanha { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(DBSCHEMA);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuscaCursoContext).Assembly);
			
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) return;
			
			optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnection"));
			
		}
	}
}
