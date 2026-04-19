using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Interfaces.Repositorio
{
    public interface IRepositorioProduto
    {
        Task<Produto> Salvar(Produto produto);
        Task<Produto> Atualizar(Produto produto);
        Task<Produto> Deletar(Produto produto);

        Task<Produto> BuscarPorId(Guid id);
        Task<Produto> BuscarPorCodigoDeBarras(long codigoDeBarras);

        Task<IEnumerable<Produto>> BuscarPorCategoriaId(Guid id);
        Task<IEnumerable<Produto>> BuscarTodos();

    }
}

