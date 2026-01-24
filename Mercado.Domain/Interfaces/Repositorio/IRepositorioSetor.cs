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
        void Salvar(Setor setor);
        void Atualizar(Setor setor);
        void Deletar(Setor setor);

        Setor BuscarPorId(Guid id);
    }
}
