using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public DayOfWeek Dia { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan Horario { get; set; }

        [Required]
        public int Nivel { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public int Tipo { get; set; }

        [BindNever]
        public List<SelectListItem> Niveis { get; set; }

        [BindNever]
        public List<SelectListItem> Statuses { get; set; }

        [BindNever]
        public List<SelectListItem> Tipos { get; set; }
    }
}
