using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class DeletarProdutoService : IDeletarProdutoService
    {
        private readonly IRepositorioProduto _repositorioProduto;
        public DeletarProdutoService(IRepositorioProduto repositorioProduto) 
        {
            this._repositorioProduto = repositorioProduto;
        }

        public async Task<ProdutoResponseDto> Executar(Guid id)
        {
            try
            {
                Produto produto = await _repositorioProduto.BuscarPorId(id);

                if (produto == null)
                {
                    throw new Exception("Produto nao encontrado");
                }

                Produto produtoDeletado = await _repositorioProduto.Deletar(produto);

                ProdutoResponseDto reponse = new ProdutoResponseDto() { Id = produtoDeletado.Id, Nome = produtoDeletado.Nome, Preco = produtoDeletado.Preco};

                return reponse;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a operaçao de Deletar!", ex);
            }
            
        }
    }
}
