using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.Entities
{
    public class Estado
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string UF { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}

