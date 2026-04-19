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
        Task<Setor> Salvar(Setor setor);
        Task<Setor> Atualizar(Setor setor);
        Task<Setor> Deletar(Setor setor);

        Task<Setor> BuscarPorId(Guid id);
        Task<IEnumerable<Setor>> BuscarTodos();
    }
}
