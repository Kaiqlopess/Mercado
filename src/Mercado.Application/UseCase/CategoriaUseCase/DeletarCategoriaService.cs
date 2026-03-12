using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class DeletarCategoriaService : IDeletarCategoriaService
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IRepositorioProduto _repositorioProduto;
        public DeletarCategoriaService(IRepositorioCategoria repositorioCategoria, IRepositorioProduto repositorioProduto) 
        {
            this._repositorioCategoria = repositorioCategoria;  
            this._repositorioProduto = repositorioProduto;
        }

        public CategoriaResponseDto Executar(Guid id)
        {
            try
            {
                Categoria categoria = _repositorioCategoria.BuscarPorId(id);

                if (categoria == null)
                {
                    throw new Exception("Categoria nao existe");
                }

                IEnumerable<Produto> produtos = _repositorioProduto.BuscarPorCategoriaId(id);

                if (produtos.Any())
                {
                    throw new Exception("há produtos com essa categoria!!");
                }

                Categoria categoriaDeletado = _repositorioCategoria.Deletar(categoria);

                CategoriaResponseDto response = new CategoriaResponseDto() { Id = categoriaDeletado.Id ,Nome = categoriaDeletado.Nome};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao de deletar", ex);
            }
           
        }
    }
}
