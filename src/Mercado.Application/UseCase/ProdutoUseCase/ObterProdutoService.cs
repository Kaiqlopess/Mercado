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

        public IEnumerable<ObterProdutoDto> ObterTodosOsProdutos()
        {
            try
            {
                IEnumerable<Produto> produtos = _repositorioProduto.BuscarTodos();

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

                }).ToList();

                return dtos;

            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a operaçao de retornar Lista Produto", ex);
            }
            
        }

        public IEnumerable<ObterProdutoDto> ObterProdutosPorCategoriaId(Guid id)
        {
            try
            {
                IEnumerable<Produto> produtos = _repositorioProduto.BuscarPorCategoriaId(id);

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

                }).ToList();

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a operaçao de retornar Lista Produto", ex);
            }
            
        }

        public ObterProdutoDto ObterProdutosPorId(Guid id)
        {
            try
            {
                Produto produto = _repositorioProduto.BuscarPorId(id);

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
                    DataDeCriacao = produto.DataDeCriacao
                };

                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar a operaçao de retornar Produto", ex);
            }
            
        }

        public ObterProdutoDto ObterProdutosPorCodigoDeBarras(long codigoDeBarras)
        {
            try
            {
                Produto produto = _repositorioProduto.BuscarPorCodigoDeBarras(codigoDeBarras);

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
                    DataDeCriacao = produto.DataDeCriacao
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
