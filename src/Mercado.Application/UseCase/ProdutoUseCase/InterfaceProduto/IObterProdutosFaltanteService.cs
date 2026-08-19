using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IObterProdutosFaltanteService
    {
        Task<IEnumerable<ProdutoFaltanteDto>> Executar();
    }
}
