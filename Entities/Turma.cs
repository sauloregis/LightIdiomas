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
    public NivelTurma Nivel { get; set; }

    [Required]
    public StatusTurma Status { get; set; } = StatusTurma.Ativa;

    [Required]
    public TipoTurma Tipo { get; set; } = TipoTurma.Grupo;

    public ICollection<Clientes> Clientes { get; set; }
}

public enum  NivelTurma
{
    Beginner1,
    Beginner2,
    Beginner3,
    Intermediate1,
    Intermediate2,
    Intermediate3,
    Intermediate4,
    Intermediate5,
    Advanced1,
    Advanced2,
    Advanced3,
}

public enum StatusTurma
{
    Ativa,
    Inativa
}

public enum TipoTurma
{
    Individual,
    Dupla,
    Grupo
}