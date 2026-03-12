using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IObterProdutoService
    {
        public IEnumerable<ObterProdutoDto> ObterTodosOsProdutos();
        public IEnumerable<ObterProdutoDto> ObterProdutosPorCategoriaId(Guid id);
        public ObterProdutoDto ObterProdutosPorId(Guid id);
        public ObterProdutoDto ObterProdutosPorCodigoDeBarras(long codigoDeBarras);
    }
}
