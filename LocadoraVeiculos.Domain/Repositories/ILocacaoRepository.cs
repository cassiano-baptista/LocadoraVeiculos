using LocadoraVeiculos.Domain.Entities;

namespace LocadoraVeiculos.Domain.Repositories;

public interface ILocacaoRepository
{
    Locacao? ObterPorId(Guid id);

    void Adicionar(Locacao locacao);
}