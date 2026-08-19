using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class ValorTotalDoProdutoService : IValorTotalDoProdutoService
    {
        private readonly IRepositorioProduto _repositorioProduto;
        public ValorTotalDoProdutoService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }
        public async Task<decimal> Executar()
        {
            try 
            {
                Decimal valorTotal = await _repositorioProduto.CalcuarValorTotalEstoque();

                return valorTotal;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao execuar a operaçao de retorno de calcular estoque", ex);
            }
        }
    }
}
