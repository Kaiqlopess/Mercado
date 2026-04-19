using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IProdutoVendidoNoCaixaService
    {
        public Task<ProdutoResponseDto> Executar(long codigoDeBarras, int quantidade);
    }
}
