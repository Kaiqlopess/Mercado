using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria
{
    public interface IObterCategoriaService
    {
        public ObterCategoriaDto ObterCategoriasPorId(Guid id);

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategorias();

        public IEnumerable<ObterCategoriaDto> ObterTodasAsCategoriasPorSetorId(Guid id);


    }
}
