using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Interfaces.Repositorio
{
    public interface IRepositorioSetor
    {
        Setor Salvar(Setor setor);
        Setor Atualizar(Setor setor);
        Setor Deletar(Setor setor);

        Setor BuscarPorId(Guid id);
        IEnumerable<Setor> BuscarTodos();
    }
}
