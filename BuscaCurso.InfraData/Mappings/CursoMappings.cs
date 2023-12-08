using BuscaCurso.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuscaCurso.InfraData.Mappings
{
	public class CursoMappings : IEntityTypeConfiguration<Curso>
	{
		public void Configure(EntityTypeBuilder<Curso> builder)
		{
			builder.ToTable("Cursos")
				.HasKey(c => c.Id);
		}
	}
}
