using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CpfValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("CPF é obrigatório.");

        string cpf = value.ToString();

        cpf = Regex.Replace(cpf, "[^0-9]", "");

        if (cpf.Length != 11)
            return new ValidationResult("CPF inválido.");

        if (new string(cpf[0], 11) == cpf)
            return new ValidationResult("CPF inválido.");

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf;
        string digito;

        int soma;
        int resto;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;

        resto = resto < 2 ? 0 : 11 - resto;

        digito = resto.ToString();

        tempCpf += digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;

        resto = resto < 2 ? 0 : 11 - resto;

        digito += resto.ToString();

        return cpf.EndsWith(digito)
            ? ValidationResult.Success
            : new ValidationResult("CPF inválido.");
    }
}

