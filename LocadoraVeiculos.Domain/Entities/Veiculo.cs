namespace LocadoraVeiculos.Domain.Entities;

public class Veiculo
{
    public Guid Id { get; private set; }
    public string Placa { get; private set; }
    public string Modelo { get; private set; }
    public decimal ValorDaDiaria { get; private set; }
    public bool Disponivel { get; private set; }

    public Veiculo(
        string placa,
        string modelo,
        decimal valorDaDiaria)
    {
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("A placa é obrigatória.");

        if (string.IsNullOrWhiteSpace(modelo))
            throw new ArgumentException("O modelo é obrigatório.");

        if (valorDaDiaria <= 0)
            throw new ArgumentException("O valor da diária deve ser maior que zero.");

        Id = Guid.NewGuid();
        Placa = placa.Trim().ToUpper();
        Modelo = modelo.Trim();
        ValorDaDiaria = valorDaDiaria;
        Disponivel = true;
    }

    public void TornarIndisponivel()
    {
        if (!Disponivel)
            throw new InvalidOperationException(
                "O veículo já está indisponível.");

        Disponivel = false;
    }

    public void TornarDisponivel()
    {
        if (Disponivel)
            throw new InvalidOperationException(
                "O veículo já está disponível.");

        Disponivel = true;
    }

    public void AlterarValorDaDiaria(decimal novoValor)
    {
        if (novoValor <= 0)
            throw new ArgumentException(
                "O valor da diária deve ser maior que zero.");

        if (novoValor == ValorDaDiaria)
            throw new ArgumentException(
                "O novo valor deve ser diferente do valor atual.");

        ValorDaDiaria = novoValor;
    }

    public bool PodeSerLocado()
    {
        return Disponivel;
    }
}