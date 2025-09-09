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
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo profissão é obrigatório.")]
        public string Profissao { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "O campo telefone é obrigatório.")]
        public string Telefone { get; set; } = string.Empty;

        public bool Whatsapp { get; set; } = false;

        [EmailAddress(ErrorMessage = "A cidade é obrigatória.")]
        public int CidadeId { get; set; }

        [EmailAddress(ErrorMessage = "A data de nascimento é campo obrigatório")]
        public DateTime DataNascimento { get; set; }

        [EmailAddress(ErrorMessage = "Gênero é campo obrigatório")]
        public Genero Genero { get; set; }

        [EmailAddress(ErrorMessage = "O estado é campo obrigatório")]
        public int EstadoId { get; set; }

        public int TurmaId { get; set; }

        [EmailAddress(ErrorMessage = "O nível de inglês é campo obrigatório.")]
        public NivelIngles NivelIngles { get; set; }

        public string Nome_Turma { get; set; } = string.Empty;

        public List<SelectListItem> Estados { get; set; }
        public List<SelectListItem> Cidades { get; set; }
        public List<SelectListItem> Turmas { get; set; }
        public List<SelectListItem> Generos { get; set; }

    }
}
