namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IValorTotalDoProdutoService
    {
        Task<Decimal> Executar();
    }
}
