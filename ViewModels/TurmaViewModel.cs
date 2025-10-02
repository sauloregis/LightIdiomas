using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.ViewModels
{
    public class TurmaViewModel
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int Dia { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string Horario { get; set; }

        [Required]
        public int Nivel { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Tipo { get; set; }

        [ValidateNever]
        public List<SelectListItem> Niveis { get; set; }

        [ValidateNever]
        public List<SelectListItem> Statuses { get; set; }

        [ValidateNever]
        public List<SelectListItem> Tipos { get; set; }
    }
}
