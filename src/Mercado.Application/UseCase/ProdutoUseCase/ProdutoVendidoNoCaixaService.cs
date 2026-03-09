



using Mercado.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class ProdutoVendidoNoCaixaService
    {
        private IRepositorioProduto _repositorioProduto;    
        public ProdutoVendidoNoCaixaService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(long codigoDeBarras, int quantidade)
        {
            var produto = _repositorioProduto.BuscarPorCodigoDeBarras(codigoDeBarras);

            if(produto == null)
            {
                throw new Exception("Produto nao existe");    
            }

            if(produto.Quantidade < quantidade)
            {
                throw new Exception("Quantidade de vendas maior que a do estoque");
            }

            produto.ProdutoVendido(quantidade);

            _repositorioProduto.Atualizar(produto);
        }


    }
}
