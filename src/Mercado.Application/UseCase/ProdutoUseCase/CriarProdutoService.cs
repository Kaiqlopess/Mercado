using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class CriarProdutoService : ICriarProdutoService
    {
        private readonly IRepositorioProduto _repositorioProduto;
        private readonly IRepositorioCategoria _repositorioCategoria;

        public CriarProdutoService(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
        {
            this._repositorioProduto = repositorioProduto;
            this._repositorioCategoria = repositorioCategoria;
        }

        public ProdutoResponseDto Executar(CriarProdutoDto dto)
        {
            try
            {
                Categoria categoria = _repositorioCategoria.BuscarPorId(dto.CategoriaId);

                if (categoria == null)
                {
                    throw new Exception("Categoria nao existe");
                }

                Produto produto = new Produto(dto.Nome, dto.Preco, dto.Quantidade, dto.Descricao, dto.Marca, dto.CodigoDeBarras, dto.Validade, dto.CategoriaId);

                Produto produtoCriado = _repositorioProduto.Salvar(produto);

                ProdutoResponseDto response = new ProdutoResponseDto() { Id = produtoCriado.Id, Nome = produtoCriado.Nome, Preco = produtoCriado.Preco };

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao criar produto", ex);
            }
            
        }
    }
}
