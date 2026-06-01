using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.Entities;

public class LocacaoTests
{
    private static PessoaFisica CriarCliente()
    {
        return new PessoaFisica(
            "João Silva",
            new Email("joao@email.com"),
            new Cpf("52998224725"));
    }

    private static Veiculo CriarVeiculo()
    {
        return new Veiculo(
            "ABC1234",
            "Corolla",
            150);
    }

    private static PeriodoLocacao CriarPeriodo()
    {
        return new PeriodoLocacao(
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 5));
    }

    [Fact]
    public void Deve_Criar_Locacao_Valida()
    {
        var cliente = CriarCliente();
        var veiculo = CriarVeiculo();
        var periodo = CriarPeriodo();

        var locacao = new Locacao(
            cliente,
            veiculo,
            periodo,
            600);

        Assert.Equal(cliente, locacao.Cliente);
        Assert.Equal(veiculo, locacao.Veiculo);
        Assert.Equal(periodo, locacao.Periodo);
        Assert.Equal(600, locacao.ValorTotal);
        Assert.False(locacao.Finalizada);
    }

    [Fact]
    public void Deve_Tornar_Veiculo_Indisponivel_Ao_Criar_Locacao()
    {
        var locacao = new Locacao(
            CriarCliente(),
            CriarVeiculo(),
            CriarPeriodo(),
            600);

        Assert.False(locacao.Veiculo.Disponivel);
    }

    [Fact]
    public void Deve_Finalizar_Locacao()
    {
        var locacao = new Locacao(
            CriarCliente(),
            CriarVeiculo(),
            CriarPeriodo(),
            600);

        locacao.Finalizar();

        Assert.True(locacao.Finalizada);
    }

    [Fact]
    public void Deve_Tornar_Veiculo_Disponivel_Ao_Finalizar_Locacao()
    {
        var locacao = new Locacao(
            CriarCliente(),
            CriarVeiculo(),
            CriarPeriodo(),
            600);

        locacao.Finalizar();

        Assert.True(locacao.Veiculo.Disponivel);
    }

    [Fact]
    public void Deve_Indicar_Que_Locacao_Esta_Ativa()
    {
        var locacao = new Locacao(
            CriarCliente(),
            CriarVeiculo(),
            CriarPeriodo(),
            600);

        Assert.True(locacao.EstaAtiva());
    }

    [Fact]
    public void Deve_Indicar_Que_Locacao_Nao_Esta_Ativa()
    {
        var locacao = new Locacao(
            CriarCliente(),
            CriarVeiculo(),
            CriarPeriodo(),
            600);

        locacao.Finalizar();

        Assert.False(locacao.EstaAtiva());
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Valor_Total_For_Invalido()
    {
        Assert.Throws<ArgumentException>(() =>
            new Locacao(
                CriarCliente(),
                CriarVeiculo(),
                CriarPeriodo(),
                0));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Veiculo_Estiver_Indisponivel()
    {
        var veiculo = CriarVeiculo();

        veiculo.TornarIndisponivel();

        Assert.Throws<InvalidOperationException>(() =>
            new Locacao(
                CriarCliente(),
                veiculo,
                CriarPeriodo(),
                600));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Finalizar_Locacao_Ja_Finalizada()
    {
        var locacao = new Locacao(
            CriarCliente(),
            CriarVeiculo(),
            CriarPeriodo(),
            600);

        locacao.Finalizar();

        Assert.Throws<InvalidOperationException>(() =>
            locacao.Finalizar());
    }
}