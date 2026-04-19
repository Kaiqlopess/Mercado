using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface ICriarProdutoService
    {
        public Task<ProdutoResponseDto> Executar(CriarProdutoDto dto);
    }
}
