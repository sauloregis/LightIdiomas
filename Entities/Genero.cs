using System.ComponentModel.DataAnnotations;

namespace LightIdiomas.Entities
{
    public enum Genero
    {
        [Display(Name = "Masculino")]
        Masculino,

        [Display(Name = "Feminino")]
        Feminino,

        [Display(Name = "Outro")]
        Outro,

        [Display(Name = "Prefiro Não Informar")]
        PrefiroNaoInformar
    }
}

