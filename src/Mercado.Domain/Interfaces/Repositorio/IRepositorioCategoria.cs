using Mercado.Domain.Models;

namespace Mercado.Domain.Interfaces.Repositorio
{
    public interface IRepositorioCategoria
    {
        Task<Categoria> Salvar(Categoria categoria);
        Task<Categoria> Atualizar(Categoria categoria);
        Task<Categoria> Deletar(Categoria categoria);

        Task<Categoria> BuscarPorId(Guid id);

        Task<IEnumerable<Categoria>> BuscarPorSetorId(Guid id);
        Task<IEnumerable<Categoria>> BuscarTodos();

    }
}
