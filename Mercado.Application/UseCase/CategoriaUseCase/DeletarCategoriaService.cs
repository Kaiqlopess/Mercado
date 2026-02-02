using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class DeletarCategoriaService
    {
        private IRepositorioCategoria _repositorioCategoria;
        private IRepositorioProduto _repositorioProduto;
        public DeletarCategoriaService(IRepositorioCategoria repositorioCategoria, IRepositorioProduto repositorioProduto) 
        {
            this._repositorioCategoria = repositorioCategoria;  
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(Guid id)
        {
            var categoria = _repositorioCategoria.BuscarPorId(id);

            if(categoria == null)
            {
                throw new Exception("Categoria nao existe");
            }

            var produtos = _repositorioProduto.BuscarPorCategoriaId(id);

            if(produtos.Any())
            {
                throw new Exception("há produtos com essa categoria!!");
            }

            _repositorioCategoria.Deletar(categoria);
        }
    }
}
