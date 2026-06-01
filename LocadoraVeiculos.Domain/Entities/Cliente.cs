using LocadoraVeiculos.Domain.ValueObjects;

namespace LocadoraVeiculos.Domain.Entities;

public abstract class Cliente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Email Email { get; private set; }

    protected Cliente(string nome, Email email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é obrigatório.");

        Id = Guid.NewGuid();
        Nome = nome.Trim();
        Email = email;
    }

    public void AlterarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é obrigatório.");

        Nome = nome.Trim();
    }

    public void AlterarEmail(Email email)
    {
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}