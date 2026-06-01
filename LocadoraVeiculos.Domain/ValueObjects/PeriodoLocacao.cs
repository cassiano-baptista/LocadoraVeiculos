namespace LocadoraVeiculos.Domain.ValueObjects;

public class PeriodoLocacao
{
    public DateTime DataInicio { get; private set; }

    public DateTime DataFim { get; private set; }

    public PeriodoLocacao(
        DateTime dataInicio,
        DateTime dataFim)
    {
        if (dataFim <= dataInicio)
            throw new ArgumentException(
                "A data final deve ser maior que a data inicial.");

        DataInicio = dataInicio;
        DataFim = dataFim;
    }

    public int QuantidadeDias()
    {
        return (DataFim - DataInicio).Days;
    }

    public bool ContemData(DateTime data)
    {
        return data >= DataInicio &&
               data <= DataFim;
    }

    public override string ToString()
    {
        return $"{DataInicio:dd/MM/yyyy} até {DataFim:dd/MM/yyyy}";
    }
}