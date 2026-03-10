using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class IDeletarCategoriaService
    {
        private IRepositorioCategoria _repositorioCategoria;
        private IRepositorioProduto _repositorioProduto;
        public IDeletarCategoriaService(IRepositorioCategoria repositorioCategoria, IRepositorioProduto repositorioProduto) 
        {
            this._repositorioCategoria = repositorioCategoria;  
            this._repositorioProduto = repositorioProduto;
        }

        public void Executar(Guid id)
        {
            Categoria categoria = _repositorioCategoria.BuscarPorId(id);

            if(categoria == null)
            {
                throw new Exception("Categoria nao existe");
            }

            IEnumerable<Produto> produtos = _repositorioProduto.BuscarPorCategoriaId(id);

            if(produtos.Any())
            {
                throw new Exception("há produtos com essa categoria!!");
            }

            _repositorioCategoria.Deletar(categoria);
        }
    }
}
