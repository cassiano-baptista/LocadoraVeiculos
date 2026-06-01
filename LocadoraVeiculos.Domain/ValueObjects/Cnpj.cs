namespace LocadoraVeiculos.Domain.ValueObjects;

public class Cnpj
{
    public string Valor { get; private set; }

    public Cnpj(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O CNPJ é obrigatório.");

        valor = Limpar(valor);

        if (!EValido(valor))
            throw new ArgumentException("CNPJ inválido.");

        Valor = valor;
    }

    private static string Limpar(string cnpj)
    {
        return cnpj.Replace(".", "")
                   .Replace("/", "")
                   .Replace("-", "")
                   .Trim();
    }

    private static bool EValido(string cnpj)
    {
        if (cnpj.Length != 14)
            return false;

        if (!cnpj.All(char.IsDigit))
            return false;

        if (cnpj.Distinct().Count() == 1)
            return false;

        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj[..12];

        int soma = 0;

        for (int i = 0; i < 12; i++)
            soma += (tempCnpj[i] - '0') * multiplicador1[i];

        int resto = soma % 11;

        int digito1 = resto < 2 ? 0 : 11 - resto;

        tempCnpj += digito1;

        soma = 0;

        for (int i = 0; i < 13; i++)
            soma += (tempCnpj[i] - '0') * multiplicador2[i];

        resto = soma % 11;

        int digito2 = resto < 2 ? 0 : 11 - resto;

        string cnpjCalculado = tempCnpj + digito2;

        return cnpj == cnpjCalculado;
    }

    public override string ToString()
    {
        return Valor;
    }
}