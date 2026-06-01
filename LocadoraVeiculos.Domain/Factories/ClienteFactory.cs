using LocadoraVeiculos.Domain.Entities;
using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Factories;

public static class ClienteFactory
{
    public static PessoaFisica CriarPessoaFisica(
        string nome,
        string email,
        string cpf)
    {
        return new PessoaFisica(
            nome,
            new Email(email),
            new Cpf(cpf));
    }

    public static PessoaJuridica CriarPessoaJuridica(
        string nome,
        string email,
        string cnpj)
    {
        return new PessoaJuridica(
            nome,
            new Email(email),
            new Cnpj(cnpj));
    }
}