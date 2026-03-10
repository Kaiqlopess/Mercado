using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class ObterCategoriaService
    {
        private IRepositorioCategoria _repositorioCategoria;
        public ObterCategoriaService(IRepositorioCategoria repositorioCategoria) 
        {
            this._repositorioCategoria = repositorioCategoria;
        }

        public ObterCategoriaDto ObterCategoriasPorId(Guid id)
        {
            Categoria categoria = _repositorioCategoria.BuscarPorId(id);

            if (categoria == null)
            {
                throw new Exception("Categoria nao existe");
            }

            ObterCategoriaDto dto = new ObterCategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };

            return dto;
        }

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategorias()
        {
            IEnumerable<Categoria> categorias = _repositorioCategoria.BuscarTodos();

            IEnumerable<ObterCategoriaDto> dtos = categorias.Select(c => new ObterCategoriaDto
            {
                Id = c.Id,
                Nome = c.Nome,
            });

            return dtos;

        }

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategoriasPorSetorId(Guid id)
        {
            IEnumerable<Categoria> categorias = _repositorioCategoria.BuscarPorSetorId(id);

            IEnumerable<ObterCategoriaDto> dtos = categorias.Select(c => new ObterCategoriaDto
            {
                Id = c.Id,
                Nome = c.Nome,
            });

            return dtos;
        }


    }
}
