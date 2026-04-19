using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IObterProdutoService
    {
        public Task<IEnumerable<ObterProdutoDto>> ObterTodosOsProdutos();
        public Task<IEnumerable<ObterProdutoDto>> ObterProdutosPorCategoriaId(Guid id);
        public Task<ObterProdutoDto> ObterProdutosPorId(Guid id);
        public Task<ObterProdutoDto> ObterProdutosPorCodigoDeBarras(long codigoDeBarras);
    }
}
