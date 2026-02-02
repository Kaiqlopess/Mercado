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
        void Salvar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(Produto produto);

        Produto BuscarPorId(Guid id);
        Produto BuscarPorCodigoDeBarras(long codigoDeBarras);

        IEnumerable<Produto> BuscarPorCategoriaId(Guid id);
        IEnumerable<Produto> BuscarTodos();

    }
}

