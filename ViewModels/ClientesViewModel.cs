using LightIdiomas.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LightIdiomas.ViewModels
{
    public class ClientesViewModel
    {
        public string Nome_Cliente { get; set; } = string.Empty;
        public string Nacionalidade { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Whatsapp { get; set; }

        public int CidadeId { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        public int EstadoId { get; set; }
        public int TurmaId { get; set; }
        public NivelIngles NivelIngles { get; set; }
        public string Nome_Turma { get; set; } = string.Empty;

        public List<SelectListItem> Estados { get; set; }
        public List<SelectListItem> Cidades { get; set; }
        public List<SelectListItem> Turmas { get; set; }
        public List<SelectListItem> Generos { get; set; }

    }
}
