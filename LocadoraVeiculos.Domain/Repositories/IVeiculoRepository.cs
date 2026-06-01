using LocadoraVeiculos.Domain.Entities;

namespace LocadoraVeiculos.Domain.Repositories;

public interface IVeiculoRepository
{
    Veiculo? ObterPorId(Guid id);

    void Adicionar(Veiculo veiculo);
}