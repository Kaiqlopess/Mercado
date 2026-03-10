using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class DeletarSetorService : IDeletarSetorService
    {
        private IRepositorioSetor _repositorioSetor;
        private IRepositorioCategoria _repositorioCategoria;
        public DeletarSetorService(IRepositorioSetor repositorioSetor, IRepositorioCategoria repositorioCategoria) 
        {
            this._repositorioSetor = repositorioSetor;
            this._repositorioCategoria = repositorioCategoria;
        }

        public void Executar(Guid id)
        {
            Setor setor = _repositorioSetor.BuscarPorId(id);

            if(setor == null)
            {
                throw new Exception("Setor nao encontrado");
            }

            IEnumerable<Categoria> categorias = _repositorioCategoria.BuscarPorSetorId(id);

            if (categorias.Any())
            {
                throw new Exception("há categorias com esse Setor!!");
            }

            _repositorioSetor.Deletar(setor);
        }
    }
}
