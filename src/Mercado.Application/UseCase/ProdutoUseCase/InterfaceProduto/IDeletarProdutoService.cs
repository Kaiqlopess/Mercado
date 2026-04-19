using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IDeletarProdutoService
    {
        public Task<ProdutoResponseDto> Executar(Guid id);
    }
}
