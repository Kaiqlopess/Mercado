using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class ObterCategoriaService
    {
        private IRepositorioCategoria _repositorioCategoria;
        public ObterCategoriaService(IRepositorioCategoria repositorioCategoria) 
        {
            this._repositorioCategoria = repositorioCategoria;
        }

        public Categoria PorId(Guid id)
        {
            var categoria = _repositorioCategoria.BuscarPorId(id);

            if (categoria == null)
            {
                throw new Exception("Categoria nao existe");
            }

            return categoria;
        }

        public IEnumerable<Categoria> Todos()
        {
            return _repositorioCategoria.BuscarTodos();
        }

        public IEnumerable<Categoria> PorSetorId(Guid id)
        {
            return _repositorioCategoria.BuscarPorSetorId(id);
        }








    }
}
