using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Entities;

public class PessoaJuridica : Cliente
{
    public Cnpj Cnpj { get; private set; }

    public PessoaJuridica(
        string nome,
        Email email,
        Cnpj cnpj)
        : base(nome, email)
    {
        Cnpj = cnpj;
    }
}