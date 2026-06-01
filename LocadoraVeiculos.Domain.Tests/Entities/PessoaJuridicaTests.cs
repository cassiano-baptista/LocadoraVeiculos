using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.Entities;

public class PessoaJuridicaTests
{
    [Fact]
    public void Deve_Criar_Pessoa_Juridica_Valida()
    {
        var email = new Email("empresa@email.com");
        var cnpj = new Cnpj("11444777000161");

        var cliente = new PessoaJuridica(
            "Empresa XPTO",
            email,
            cnpj);

        Assert.Equal("Empresa XPTO", cliente.Nome);
        Assert.Equal(email, cliente.Email);
        Assert.Equal(cnpj, cliente.Cnpj);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Nome_For_Vazio()
    {
        var email = new Email("empresa@email.com");
        var cnpj = new Cnpj("11444777000161");

        Assert.Throws<ArgumentException>(() =>
            new PessoaJuridica(
                "",
                email,
                cnpj));
    }

    [Fact]
    public void Deve_Alterar_Nome_Do_Cliente()
    {
        var cliente = new PessoaJuridica(
            "Empresa XPTO",
            new Email("empresa@email.com"),
            new Cnpj("11444777000161"));

        cliente.AlterarNome("Nova Empresa");

        Assert.Equal("Nova Empresa", cliente.Nome);
    }

    [Fact]
    public void Deve_Alterar_Email_Do_Cliente()
    {
        var cliente = new PessoaJuridica(
            "Empresa XPTO",
            new Email("empresa@email.com"),
            new Cnpj("11444777000161"));

        var novoEmail = new Email("novo@email.com");

        cliente.AlterarEmail(novoEmail);

        Assert.Equal(novoEmail, cliente.Email);
    }
}