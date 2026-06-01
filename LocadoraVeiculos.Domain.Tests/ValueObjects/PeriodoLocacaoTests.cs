using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Tests.ValueObjects;

public class PeriodoLocacaoTests
{
    [Fact]
    public void Deve_Criar_Periodo_Valido()
    {
        var inicio = new DateTime(2026, 6, 1);
        var fim = new DateTime(2026, 6, 5);

        var periodo = new PeriodoLocacao(
            inicio,
            fim);

        Assert.Equal(inicio, periodo.DataInicio);
        Assert.Equal(fim, periodo.DataFim);
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Data_Final_For_Menor_Que_Data_Inicial()
    {
        var inicio = new DateTime(2026, 6, 5);
        var fim = new DateTime(2026, 6, 1);

        Assert.Throws<ArgumentException>(() =>
            new PeriodoLocacao(
                inicio,
                fim));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Quando_Data_Final_For_Igual_A_Data_Inicial()
    {
        var data = new DateTime(2026, 6, 1);

        Assert.Throws<ArgumentException>(() =>
            new PeriodoLocacao(
                data,
                data));
    }

    [Fact]
    public void Deve_Calcular_Quantidade_De_Dias()
    {
        var periodo = new PeriodoLocacao(
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 5));

        Assert.Equal(
            4,
            periodo.QuantidadeDias());
    }

    [Fact]
    public void Deve_Conter_Data_Dentro_Do_Periodo()
    {
        var periodo = new PeriodoLocacao(
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 5));

        Assert.True(
            periodo.ContemData(
                new DateTime(2026, 6, 3)));
    }

    [Fact]
    public void Nao_Deve_Conter_Data_Fora_Do_Periodo()
    {
        var periodo = new PeriodoLocacao(
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 5));

        Assert.False(
            periodo.ContemData(
                new DateTime(2026, 6, 10)));
    }
}