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
        public NivelTurma Nivel { get; set; }

        [Required]
        public StatusTurma Status { get; set; }

        [Required]
        public TipoTurma Tipo { get; set; }

        public List<SelectListItem> Niveis { get; set; }
        public List<SelectListItem> Statuses { get; set; }
        public List<SelectListItem> Tipos { get; set; }
    }
}
