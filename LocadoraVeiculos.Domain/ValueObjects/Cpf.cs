namespace LocadoraVeiculos.Domain.ValueObjects;

public class Cpf
{
    public string Valor { get; private set; }

    public Cpf(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O CPF é obrigatório.");

        valor = Limpar(valor);

        if (!EValido(valor))
            throw new ArgumentException("CPF inválido.");

        Valor = valor;
    }

    private static string Limpar(string cpf)
    {
        return cpf.Replace(".", "")
                  .Replace("-", "")
                  .Trim();
    }

    private static bool EValido(string cpf)
    {
        if (cpf.Length != 11)
            return false;

        if (!cpf.All(char.IsDigit))
            return false;

        if (cpf.Distinct().Count() == 1)
            return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf[..9];

        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += (tempCpf[i] - '0') * multiplicador1[i];

        int resto = soma % 11;

        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCpf += digito1;

        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += (tempCpf[i] - '0') * multiplicador2[i];

        resto = soma % 11;

        int digito2 = resto < 2 ? 0 : 11 - resto;

        string cpfCalculado = tempCpf + digito2;

        return cpf == cpfCalculado;
    }

    public override string ToString()
    {
        return Valor;
    }
}