using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.ValueObjects;

public class CnpjTests
{
    [Fact]
    public void Deve_Criar_Cnpj_Valido()
    {
        var cnpjValido = "11444777000161";

        var cnpj = new Cnpj(cnpjValido);

        Assert.Equal(cnpjValido, cnpj.Valor);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cnpj_For_Vazio()
    {
        Assert.Throws<ArgumentException>(() =>
            new Cnpj(""));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cnpj_For_Nulo()
    {
        string cnpj = null!;

        Assert.Throws<ArgumentException>(() =>
            new Cnpj(cnpj));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cnpj_For_Invalido()
    {
        Assert.Throws<ArgumentException>(() =>
            new Cnpj("12345678000100"));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cnpj_Possuir_Todos_Digitos_Iguais()
    {
        Assert.Throws<ArgumentException>(() =>
            new Cnpj("11111111111111"));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cnpj_Possuir_Tamanho_Invalido()
    {
        Assert.Throws<ArgumentException>(() =>
            new Cnpj("123"));
    }
}