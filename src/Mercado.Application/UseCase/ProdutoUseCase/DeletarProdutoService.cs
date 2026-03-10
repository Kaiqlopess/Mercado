using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class DeletarProdutoService : IDeletarProdutoService
    {
        private IRepositorioProduto _repositorioProduto;
        public DeletarProdutoService(IRepositorioProduto repositorioProduto) 
        {
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(Guid id)
        {
            Produto produto = _repositorioProduto.BuscarPorId(id);

            if(produto == null)
            {
                throw new Exception("Produto nao encontrado"); 
            }

            _repositorioProduto.Deletar(produto);
        }
    }
}
