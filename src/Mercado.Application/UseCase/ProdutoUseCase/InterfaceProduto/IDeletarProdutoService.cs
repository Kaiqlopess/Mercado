using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IDeletarProdutoService
    {
        public ProdutoResponseDto Executar(Guid id);
    }
}
