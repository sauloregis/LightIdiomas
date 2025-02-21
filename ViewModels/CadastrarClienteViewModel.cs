namespace LightIdiomas.ViewModels
{
    public class CadastrarClienteViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; } //Mascara de email
        public string Telefone { get; set; } //require o tamanho do telefone
        public bool Whatsapp { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string Nacionalidade { get; set; } 
        public string RG { get; set; }
        public string CPF { get; set; }
    }
}
