using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.Entities
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; set; }

        [Required]
        public string Nacionalidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(20)]
        public string RG { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        public string Profissao { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(13)]
        public string Telefone { get; set; }

        [Required]
        public bool Whatsapp { get; set; }
    }
}

