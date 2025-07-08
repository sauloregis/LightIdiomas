using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.Entities
{
    public class Cidade
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }
    }
}

