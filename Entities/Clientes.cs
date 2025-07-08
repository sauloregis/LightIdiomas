using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.Entities
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nm_Cliente { get; set; } = string.Empty;

        [Required]
        public string Nacionalidade { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string RG { get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string CPF { get; set; } = string.Empty; 

        public string Profissao { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(13)]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        public bool Whatsapp { get; set; }
    }
}

