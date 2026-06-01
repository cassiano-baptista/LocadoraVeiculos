using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Services;

public class CalculadoraLocacaoService
{
    public decimal Calcular(
        Veiculo veiculo,
        PeriodoLocacao periodo)
    {
        if (veiculo is null)
            throw new ArgumentNullException(nameof(veiculo));

        if (periodo is null)
            throw new ArgumentNullException(nameof(periodo));

        return veiculo.ValorDaDiaria * periodo.QuantidadeDias();
    }
}