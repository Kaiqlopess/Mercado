using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class AtualizarCategoriaService : IAtualizarCategoriaService
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        public AtualizarCategoriaService(IRepositorioCategoria repositorioCategoria)
        {
            this._repositorioCategoria = repositorioCategoria;
        }

        public async Task<CategoriaResponseDto> Executar(Guid id, AtualizarCategoriaDto dto)
        {
            try
            {
                Categoria categoria = await _repositorioCategoria.BuscarPorId(id);

                if (categoria == null)
                {
                    throw new Exception("Categoria nao encontrado");
                }

                categoria.Modificar(dto.Nome, dto.Descricao);

                Categoria categoriaAtualizada = await _repositorioCategoria.Atualizar(categoria);

                CategoriaResponseDto response = new CategoriaResponseDto() { Id = categoriaAtualizada.Id, Nome = categoriaAtualizada.Nome};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao Atualizar!", ex);

            }
            
        }
                
    }
}
