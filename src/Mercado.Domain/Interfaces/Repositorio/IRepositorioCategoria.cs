using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Interfaces.Repositorio
{
    public interface IRepositorioCategoria
    {
        Categoria Salvar(Categoria categoria);
        Categoria Atualizar(Categoria categoria);
        Categoria Deletar(Categoria categoria);

        Categoria BuscarPorId(Guid id);

        IEnumerable<Categoria> BuscarPorSetorId(Guid id);
        IEnumerable<Categoria> BuscarTodos();

    }
}
