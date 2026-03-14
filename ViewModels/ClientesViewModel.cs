using LightIdiomas.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.ViewModels
{
    public class ClientesViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome_Cliente { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O campo Nacionalidade é obrigatório.")]
        public string Nacionalidade { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O campo endereço é obrigatório.")]
        public string Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        public string RG { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [CpfValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo profissão é obrigatório.")]
        public string Profissao { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo telefone é obrigatório.")]
        [Phone(ErrorMessage = "Informe um telefone válido.")]
        public string Telefone { get; set; } = string.Empty;

        public bool Whatsapp { get; set; } = false;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "A data de nascimento é campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Gênero é campo obrigatório")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "O estado é campo obrigatório")]
        public int EstadoId { get; set; }

        public int? TurmaId { get; set; }

        [Required(ErrorMessage = "O nível de inglês é campo obrigatório.")]
        public NivelIngles NivelIngles { get; set; }

        public string Nome_Turma { get; set; } = string.Empty;

        public List<SelectListItem> Estados { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Cidades { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Turmas { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Generos { get; set; } = new List<SelectListItem>();

    }
}
