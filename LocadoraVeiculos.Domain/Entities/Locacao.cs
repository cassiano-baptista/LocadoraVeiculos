using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Entities;

public class Locacao
{
    public Guid Id { get; private set; }
    public Cliente Cliente { get; private set; }
    public Veiculo Veiculo { get; private set; }
    public PeriodoLocacao Periodo { get; private set; }
    public decimal ValorTotal { get; private set; }
    public bool Finalizada { get; private set; }

    public Locacao(
        Cliente cliente,
        Veiculo veiculo,
        PeriodoLocacao periodo,
        decimal valorTotal)
    {
        if (cliente is null)
            throw new ArgumentNullException(nameof(cliente));

        if (veiculo is null)
            throw new ArgumentNullException(nameof(veiculo));

        if (periodo is null)
            throw new ArgumentNullException(nameof(periodo));

        if (valorTotal <= 0)
            throw new ArgumentException(
                "O valor total deve ser maior que zero.");

        if (!veiculo.PodeSerLocado())
            throw new InvalidOperationException(
                "O veículo não está disponível para locação.");

        Id = Guid.NewGuid();

        Cliente = cliente;
        Veiculo = veiculo;
        Periodo = periodo;
        ValorTotal = valorTotal;

        Finalizada = false;

        veiculo.TornarIndisponivel();
    }

    public void Finalizar()
    {
        if (Finalizada)
            throw new InvalidOperationException(
                "A locação já foi finalizada.");

        Finalizada = true;

        Veiculo.TornarDisponivel();
    }

    public bool EstaAtiva()
    {
        return !Finalizada;
    }
}