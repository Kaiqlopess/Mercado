using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class ObterCategoriaService : IObterCategoriaService
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        public ObterCategoriaService(IRepositorioCategoria repositorioCategoria) 
        {
            this._repositorioCategoria = repositorioCategoria;
        }

        public ObterCategoriaDto ObterCategoriasPorId(Guid id)
        {
            try
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
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao de retonrar a categoria");
            }
            
        }

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategorias()
        {
            try
            {
                IEnumerable<Categoria> categorias = _repositorioCategoria.BuscarTodos();

                IEnumerable<ObterCategoriaDto> dtos = categorias.Select(c => new ObterCategoriaDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                });

                return dtos;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao de Listar", ex);
            }
            

        }

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategoriasPorSetorId(Guid id)
        {
            try
            {
                IEnumerable<Categoria> categorias = _repositorioCategoria.BuscarPorSetorId(id);

                IEnumerable<ObterCategoriaDto> dtos = categorias.Select(c => new ObterCategoriaDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                });

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar a operaçao de listar");
            }
            
        }


    }
}
