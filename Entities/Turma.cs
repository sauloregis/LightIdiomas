using System.ComponentModel.DataAnnotations;
using LightIdiomas.Entities;

public class Turma
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    public ICollection<Clientes> Clientes { get; set; }
}