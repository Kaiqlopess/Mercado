using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria
{
    public interface IObterCategoriaService
    {
        public Task<ObterCategoriaDto> ObterCategoriasPorId(Guid id);

        public Task<IEnumerable<ObterCategoriaDto>> ObterTodasAsCategorias();

        public Task<IEnumerable<ObterCategoriaDto>> ObterTodasAsCategoriasPorSetorId(Guid id);


    }
}
