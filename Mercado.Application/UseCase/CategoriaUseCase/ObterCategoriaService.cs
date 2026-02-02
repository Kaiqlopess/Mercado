using Mercado.Application.Dtos.CategoriaDto;
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

        public ObterCategoriaDto ObterTodasAsCategoriasPorId(Guid id)
        {
            var categoria = _repositorioCategoria.BuscarPorId(id);

            if (categoria == null)
            {
                throw new Exception("Categoria nao existe");
            }

            var dto = new ObterCategoriaDto
            {
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
            };

            return dto;
        }

        public IEnumerable<ObterCategoriaDto> ObrterTodasAsCategorias()
        {
            var categorias = _repositorioCategoria.BuscarTodos();

            var dtos = categorias.Select(c => new ObterCategoriaDto
            {
                Nome = c.Nome,
                Descricao = c.Descricao
            });

            return dtos;

        }

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategoriasPorSetorId(Guid id)
        {
            var categorias = _repositorioCategoria.BuscarPorSetorId(id);

            var dtos = categorias.Select(c => new ObterCategoriaDto
            {
                Nome = c.Nome,
                Descricao = c.Descricao
            });

            return dtos;
        }


    }
}
