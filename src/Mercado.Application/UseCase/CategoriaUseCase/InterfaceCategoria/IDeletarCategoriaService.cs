using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria
{
    public interface IDeletarCategoriaService
    {
        public Task<CategoriaResponseDto> Executar(Guid id);
    }
}
