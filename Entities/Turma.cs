using System.ComponentModel.DataAnnotations;
using LightIdiomas.Entities;

public class Turma
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public DayOfWeek Dia { get; set; }

    [Required]
    public TimeSpan Horario { get; set; }

    [Required]
    public NivelTurma NivelIngles { get; set; }

    [Required]
    public StatusTurma Status { get; set; } = StatusTurma.Ativa;

    [Required]
    public TipoTurma Tipo { get; set; } = TipoTurma.Grupo;

    public ICollection<Clientes> Clientes { get; set; }
}
