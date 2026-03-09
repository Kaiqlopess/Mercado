using Mercado.Application.Dtos;
using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public class CriarProdutoService
    {
        private IRepositorioProduto _repositorioProduto;
        private IRepositorioCategoria _repositorioCategoria;

        public CriarProdutoService(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
        {
            this._repositorioProduto = repositorioProduto;
            this._repositorioCategoria = repositorioCategoria;
        }

        public void Executar(CriarProdutoDto dto)
        {
            var categoria = _repositorioCategoria.BuscarPorId(dto.CategoriaId);

            if(categoria == null) {
                throw new Exception("Categoria nao existe");
            }




            var produto = new Produto(dto.Nome, dto.Preco, dto.Quantidade, dto.Descricao, dto.Marca, dto.CodigoDeBarras, dto.Validade, dto.CategoriaId);

            _repositorioProduto.Salvar(produto);
        }
    }
}
