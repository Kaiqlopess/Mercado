using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class AtualizarProdutoService : IAtualizarProdutoService
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public AtualizarProdutoService(IRepositorioProduto repositorioProduto)
        {
            this._repositorioProduto = repositorioProduto;
        }

        public ProdutoResponseDto Executar(Guid id, AtualizarProdutoDto dto)
        {

            try
            {
                Produto produto = _repositorioProduto.BuscarPorId(id);

                if (produto == null)
                {
                    throw new Exception("Produto nao existe");
                }

                produto.ModificarParaAtualizar(dto.Preco, dto.Quantidade);

                Produto ProdutoAtualizado = _repositorioProduto.Atualizar(produto);

                ProdutoResponseDto response = new ProdutoResponseDto() { Id = ProdutoAtualizado.Id, Nome = ProdutoAtualizado.Nome, Preco = ProdutoAtualizado.Preco};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a opreçao de atualizar!", ex);
            }
            
        }
    }
}
