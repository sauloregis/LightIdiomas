using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; set; }

        [Required]
        public int NacionalidadeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco_Rua { get; set; }

        [Required]
        [StringLength(10)]
        public string Endereco_Numero { get; set; }

        [Required]
        [StringLength(8)]
        public string Endereco_CEP { get; set; }

        [Required]
        [StringLength(50)]
        public string Endereco_Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Endereco_Estado { get; set; }

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

