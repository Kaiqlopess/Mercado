using Mercado.Application.Dtos;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase
{
    public class CriarProdutoService
    {
        private IRepositorioProduto _repositoro;
        private IRepositorioCategoria _categoria;

        public CriarProdutoService(IRepositorioProduto repositoro, IRepositorioCategoria categoria)
        {
            this._repositoro = repositoro;
            this._categoria = categoria;
        }

        public async Task Executar(CriarProdutoDto dto)
        {
            var categoria =   _categoria.BuscarPorId(dto.CategoriaId);

            if(categoria == null) {
                throw new Exception("Categoria Nao existe");
            }

            var produto = new Produto(dto.Nome, dto.Preco, dto.Quantidade, dto.Descricao, dto.Marca, dto.CodigoDeBarras, dto.Validade, dto.CategoriaId);

             _repositoro.Salvar(produto);
        }
    }
}
