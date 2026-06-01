using LocadoraVeiculos.Domain.Entities;

namespace LocadoraVeiculos.Domain.Repositories;

public interface IClienteRepository
{
    Cliente? ObterPorId(Guid id);

    void Adicionar(Cliente cliente);
}