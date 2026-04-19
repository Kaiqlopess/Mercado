using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class ObterProdutoService : IObterProdutoService
    {
        private readonly IRepositorioProduto _repositorioProduto;
        public ObterProdutoService(IRepositorioProduto repositorioProduto) 
        {
            this._repositorioProduto = repositorioProduto;
        }

        public async Task<IEnumerable<ObterProdutoDto>> ObterTodosOsProdutos()
        {
            try
            {
                IEnumerable<Produto> produtos = await _repositorioProduto.BuscarTodos();

                var dtos = produtos.Select(p => new ObterProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Quantidade = p.Quantidade,
                    Marca = p.Marca,
                    Descricao = p.Descricao,
                    Validade = p.Validade,
                    CodigoDeBarras = p.CodigoDeBarras,
                    DataDeCriacao = p.DataDeCriacao,
                    CategoriaId = p.CategoriaId,
                    CategoriaNome = p.Categoria.Nome
                }).ToList();

                return dtos;

            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a operaçao de retornar Lista Produto", ex);
            }
            
        }

        public async Task<IEnumerable<ObterProdutoDto>> ObterProdutosPorCategoriaId(Guid id)
        {
            try
            {
                IEnumerable<Produto> produtos = await _repositorioProduto.BuscarPorCategoriaId(id);

                var dtos = produtos.Select(p => new ObterProdutoDto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    Quantidade = p.Quantidade,
                    Marca = p.Marca,
                    Descricao = p.Descricao,
                    Validade = p.Validade,
                    CodigoDeBarras = p.CodigoDeBarras,
                    DataDeCriacao = p.DataDeCriacao,
                    CategoriaId = p.CategoriaId,
                    CategoriaNome = p.Categoria.Nome
                }).ToList();

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a operaçao de retornar Lista Produto", ex);
            }
            
        }

        public async Task<ObterProdutoDto> ObterProdutosPorId(Guid id)
        {
            try
            {
                Produto produto = await _repositorioProduto.BuscarPorId(id);

                if (produto == null)
                {
                    throw new Exception("Produto nao existe");
                }

                ObterProdutoDto dto = new ObterProdutoDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    Marca = produto.Marca,
                    Descricao = produto.Descricao,
                    Validade = produto.Validade,
                    CodigoDeBarras = produto.CodigoDeBarras,
                    DataDeCriacao = produto.DataDeCriacao,
                    CategoriaId = produto.CategoriaId,
                    CategoriaNome = produto.Categoria.Nome
                };

                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a operaçao de retornar Produto", ex);
            }
            
        }

        public async Task<ObterProdutoDto> ObterProdutosPorCodigoDeBarras(long codigoDeBarras)
        {
            try
            {
                Produto produto = await _repositorioProduto.BuscarPorCodigoDeBarras(codigoDeBarras);

                if (produto == null)
                {
                    throw new Exception("Produto nao existe");
                }

                ObterProdutoDto dto = new ObterProdutoDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    Marca = produto.Marca,
                    Descricao = produto.Descricao,
                    Validade = produto.Validade,
                    CodigoDeBarras = produto.CodigoDeBarras,
                    DataDeCriacao = produto.DataDeCriacao,
                    CategoriaId = produto.CategoriaId,
                    CategoriaNome = produto.Categoria.Nome
                };

                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a operaçao de retornar Produto", ex);
            }
            
        }
    }
}
