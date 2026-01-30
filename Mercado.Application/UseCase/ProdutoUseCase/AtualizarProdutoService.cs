using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class AtualizarProdutoService
    {
        private IRepositorioProduto _repositorioProduto;

        public AtualizarProdutoService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(Guid id, AtualizarProdutoDto dto)
        {
            var produto = _repositorioProduto.BuscarPorId(id);

            if(produto == null)
            {
                throw new Exception("Produto nao existe");
            }

            produto.Modificar(dto.Preco, dto.Quantidade);

            _repositorioProduto.Atualizar(produto);
        }
    }
}
