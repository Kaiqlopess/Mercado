using Mercado.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class DeletarProdutoService
    {
        private IRepositorioProduto _repositorioProduto;
        public DeletarProdutoService(IRepositorioProduto repositorioProduto) 
        {
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(Guid id)
        {
            var produto = _repositorioProduto.BuscarPorId(id);

            if(produto == null)
            {
                throw new Exception("Produto nao encontrado"); 
            }

            _repositorioProduto.Deletar(produto);
        }
    }
}
