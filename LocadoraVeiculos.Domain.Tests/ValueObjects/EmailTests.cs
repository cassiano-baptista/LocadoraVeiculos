using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Deve_Criar_Email_Valido()
    {
        var endereco = "teste@gmail.com";

        var email = new Email(endereco);

        Assert.Equal(endereco, email.Valor);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Email_For_Vazio()
    {
        var endereco = "";

        Assert.Throws<ArgumentException>(() =>
            new Email(endereco));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Email_For_Nulo()
    {
        string endereco = null!;

        Assert.Throws<ArgumentException>(() =>
            new Email(endereco));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Email_For_Invalido()
    {
        var endereco = "email_invalido";

        Assert.Throws<ArgumentException>(() =>
            new Email(endereco));
    }
}