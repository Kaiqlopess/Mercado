using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface ICriarProdutoService
    {
        public ProdutoResponseDto Executar(CriarProdutoDto dto);
    }
}
