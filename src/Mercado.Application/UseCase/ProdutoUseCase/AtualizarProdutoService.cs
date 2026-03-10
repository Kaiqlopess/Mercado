using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class AtualizarProdutoService : IAtualizarProdutoService
    {
        private IRepositorioProduto _repositorioProduto;

        public AtualizarProdutoService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(Guid id, AtualizarProdutoDto dto)
        {
            Produto produto = _repositorioProduto.BuscarPorId(id);

            if(produto == null)
            {
                throw new Exception("Produto nao existe");
            }

            produto.Modificar(dto.Preco, dto.Quantidade);

            _repositorioProduto.Atualizar(produto);
        }
    }
}
