using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.Factories;

namespace LocadoraVeiculos.Domain.Tests.Factories;

public class ClienteFactoryTests
{
    [Fact]
    public void Deve_Criar_Pessoa_Fisica()
    {
        var cliente = ClienteFactory.CriarPessoaFisica(
            "João Silva",
            "joao@email.com",
            "52998224725");

        Assert.NotNull(cliente);
        Assert.IsType<PessoaFisica>(cliente);

        Assert.Equal(
            "João Silva",
            cliente.Nome);

        Assert.Equal(
            "joao@email.com",
            cliente.Email.Valor);

        Assert.Equal(
            "52998224725",
            cliente.Cpf.Valor);
    }

    [Fact]
    public void Deve_Criar_Pessoa_Juridica()
    {
        var cliente = ClienteFactory.CriarPessoaJuridica(
            "Empresa XPTO",
            "empresa@email.com",
            "11444777000161");

        Assert.NotNull(cliente);
        Assert.IsType<PessoaJuridica>(cliente);

        Assert.Equal(
            "Empresa XPTO",
            cliente.Nome);

        Assert.Equal(
            "empresa@email.com",
            cliente.Email.Valor);

        Assert.Equal(
            "11444777000161",
            cliente.Cnpj.Valor);
    }
}