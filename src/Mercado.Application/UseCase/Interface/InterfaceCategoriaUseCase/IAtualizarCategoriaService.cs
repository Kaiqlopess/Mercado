using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

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
            Categoria categoria = _repositorioCategoria.BuscarPorId(id);

            if(categoria == null)
            {
                throw new Exception("Categoria nao encontrado");
            }

            categoria.Modificar(dto.Nome, dto.Descricao);

            _repositorioCategoria.Atualizar(categoria);
        }
                
    }
}
