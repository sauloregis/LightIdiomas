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

        [Required]
        public int CidadeId { get; set; }

        public Cidade Cidade { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public Genero Genero { get; set; }

        public NivelIngles NivelIngles { get; set; }
        public int? TurmaId { get; set; } // Pode ser null para alunos sem turma
        public Turma? Turma { get; set; }
        public bool Ativo { get; set; } = true;
    }
}

