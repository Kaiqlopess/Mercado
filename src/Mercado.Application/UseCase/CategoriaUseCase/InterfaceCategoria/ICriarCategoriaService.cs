using Mercado.Application.Dtos.CategoriaDto;

namespace Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria
{
    public interface ICriarCategoriaService
    {
        public Task<CategoriaResponseDto> Executar(CriarCategoriaDto dto);
    }
}

