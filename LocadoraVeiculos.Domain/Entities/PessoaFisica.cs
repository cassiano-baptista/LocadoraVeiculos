using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Entities;

public class PessoaFisica : Cliente
{
    public Cpf Cpf { get; private set; }

    public PessoaFisica(
        string nome,
        Email email,
        Cpf cpf)
        : base(nome, email)
    {
        Cpf = cpf;
    }
}