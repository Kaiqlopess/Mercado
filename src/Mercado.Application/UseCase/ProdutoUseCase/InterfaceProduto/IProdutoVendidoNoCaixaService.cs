using Mercado.Application.Dtos.ProdutoDto;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IProdutoVendidoNoCaixaService
    {
        public ProdutoResponseDto Executar(long codigoDeBarras, int quantidade);
    }
}
