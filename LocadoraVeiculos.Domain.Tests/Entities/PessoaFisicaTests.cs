using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.Entities;

public class PessoaFisicaTests
{
    [Fact]
    public void Deve_Criar_Pessoa_Fisica_Valida()
    {
        var email = new Email("teste@gmail.com");
        var cpf = new Cpf("52998224725");

        var cliente = new PessoaFisica(
            "João Silva",
            email,
            cpf);

        Assert.Equal("João Silva", cliente.Nome);
        Assert.Equal(email, cliente.Email);
        Assert.Equal(cpf, cliente.Cpf);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Nome_For_Vazio()
    {
        var email = new Email("teste@gmail.com");
        var cpf = new Cpf("52998224725");

        Assert.Throws<ArgumentException>(() =>
            new PessoaFisica(
                "",
                email,
                cpf));
    }

    [Fact]
    public void Deve_Alterar_Nome_Do_Cliente()
    {
        var cliente = new PessoaFisica(
            "João",
            new Email("teste@gmail.com"),
            new Cpf("52998224725"));

        cliente.AlterarNome("Maria");

        Assert.Equal("Maria", cliente.Nome);
    }

    [Fact]
    public void Deve_Alterar_Email_Do_Cliente()
    {
        var cliente = new PessoaFisica(
            "João",
            new Email("teste@gmail.com"),
            new Cpf("52998224725"));

        var novoEmail = new Email("novo@gmail.com");

        cliente.AlterarEmail(novoEmail);

        Assert.Equal(novoEmail, cliente.Email);
    }
}