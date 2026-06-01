using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.ValueObjects;

public class CpfTests
{
    [Fact]
    public void Deve_Criar_Cpf_Valido()
    {
        var cpfValido = "12956314742";

        var cpf = new Cpf(cpfValido);

        Assert.Equal(cpfValido, cpf.Valor);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cpf_For_Vazio()
    {
        var cpf = "";

        Assert.Throws<ArgumentException>(() =>
            new Cpf(cpf));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cpf_For_Nulo()
    {
        string cpf = null!;

        Assert.Throws<ArgumentException>(() =>
            new Cpf(cpf));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cpf_For_Invalido()
    {
        var cpf = "12345678900";

        Assert.Throws<ArgumentException>(() =>
            new Cpf(cpf));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cpf_Possuir_Todos_Digitos_Iguais()
    {
        var cpf = "11111111111";

        Assert.Throws<ArgumentException>(() =>
            new Cpf(cpf));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Cpf_Possuir_Tamanho_Invalido()
    {
        var cpf = "123";

        Assert.Throws<ArgumentException>(() =>
            new Cpf(cpf));
    }

}