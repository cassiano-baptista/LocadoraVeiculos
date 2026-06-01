using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.Services;
using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.Services;

public class CalculadoraLocacaoServiceTests
{
    [Fact]
    public void Deve_Calcular_Valor_Total_Da_Locacao()
    {
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        var periodo = new PeriodoLocacao(
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 5));

        var service = new CalculadoraLocacaoService();

        var valor = service.Calcular(
            veiculo,
            periodo);

        Assert.Equal(600, valor);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Veiculo_For_Nulo()
    {
        var periodo = new PeriodoLocacao(
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 5));

        var service = new CalculadoraLocacaoService();

        Assert.Throws<ArgumentNullException>(() =>
            service.Calcular(
                null!,
                periodo));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Periodo_For_Nulo()
    {
        var veiculo = new Veiculo(
            "ABC1234",
            "Corolla",
            150);

        var service = new CalculadoraLocacaoService();

        Assert.Throws<ArgumentNullException>(() =>
            service.Calcular(
                veiculo,
                null!));
    }
}