using Mercado.Application.Dtos.CategoriaDto;



namespace Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria
{
    public interface IAtualizarCategoriaService
    {
        public Task<CategoriaResponseDto> Executar(Guid id, AtualizarCategoriaDto dto);
    }
}
