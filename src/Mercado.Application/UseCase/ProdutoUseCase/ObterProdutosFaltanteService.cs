using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class ObterProdutosFaltanteService : IObterProdutosFaltanteService
    {
        private readonly IRepositorioProduto _repositorioProduto;
        public ObterProdutosFaltanteService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }
        public async Task<IEnumerable<ProdutoFaltanteDto>> Executar()
        {
            try
            {
                IEnumerable<Produto> produtos = await _repositorioProduto.ObterProdutosComEstoqueBaixo();

                return produtos.Select(p => new ProdutoFaltanteDto
                {
                    Nome = p.Nome,
                    EstoqueAtual = p.Quantidade,
                    EstoqueMinimo = 2,
                    SugestaoCompra = 2 - p.Quantidade 
                });

            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar o service retorno dos produtos que estao em falta");
            }
        }
    }
}
