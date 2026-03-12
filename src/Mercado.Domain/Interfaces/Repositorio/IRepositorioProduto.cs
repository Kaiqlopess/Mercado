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
        Produto Salvar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto Deletar(Produto produto);

        Produto BuscarPorId(Guid id);
        Produto BuscarPorCodigoDeBarras(long codigoDeBarras);

        IEnumerable<Produto> BuscarPorCategoriaId(Guid id);
        IEnumerable<Produto> BuscarTodos();

    }
}

