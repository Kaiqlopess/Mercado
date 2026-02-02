using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class AtualizarCategoriaService
    {
        private IRepositorioCategoria _repositorioCategoria;
        public AtualizarCategoriaService(IRepositorioCategoria repositorioCategoria)
        {
            this._repositorioCategoria = repositorioCategoria;
        }

        public void Executar(Guid id, AtualizarCategoriaDto dto)
        {
            var categoria = _repositorioCategoria.BuscarPorId(id);

            if(categoria == null)
            {
                throw new Exception("Categoria nao encontrado");
            }

            categoria.Modificar(dto.Nome, dto.Descricao);

            _repositorioCategoria.Atualizar(categoria);
        }
                
    }
}
