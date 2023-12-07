using System.ComponentModel.DataAnnotations.Schema;

namespace BuscaCurso.Domain.Models
{
	public class Curso
	{
        public Guid	Id { get; set; }
        public string Titulo { get; set; }
        public string Professor { get; set; }
        public int CargaHoraria { get; set; }
        public string Descricao { get; set; }
		[NotMapped]
		public string Link { get; set; }
    }
}
