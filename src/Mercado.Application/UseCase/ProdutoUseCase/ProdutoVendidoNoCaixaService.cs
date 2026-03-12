



using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class ProdutoVendidoNoCaixaService : IProdutoVendidoNoCaixaService
    {
        private readonly IRepositorioProduto _repositorioProduto;    
        public ProdutoVendidoNoCaixaService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }

        public ProdutoResponseDto Executar(long codigoDeBarras, int quantidade)
        {
            try
            {
                Produto produto = _repositorioProduto.BuscarPorCodigoDeBarras(codigoDeBarras);

                if (produto == null)
                {
                    throw new Exception("Produto nao existe");
                }

                if (produto.Quantidade < quantidade)
                {
                    throw new Exception("Quantidade de vendas maior que a do estoque");
                }

                produto.ProdutoVendido(quantidade);     

                Produto produtoAtualizado = _repositorioProduto.Atualizar(produto);

                ProdutoResponseDto produtoResponse = new ProdutoResponseDto() { Id = produtoAtualizado.Id, Nome = produtoAtualizado.Nome, Preco = produtoAtualizado.Preco };

                return produtoResponse;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao execuar a operaçao de vendas no caixa", ex);
            }
            ;
        }


    }
}
