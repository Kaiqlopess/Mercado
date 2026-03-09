using Mercado.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class DeletarSetorService
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
            var setor = _repositorioSetor.BuscarPorId(id);

            if(setor == null)
            {
                throw new Exception("Setor nao encontrado");
            }

            var categorias = _repositorioCategoria.BuscarPorSetorId(id);

            if (categorias.Any())
            {
                throw new Exception("há categorias com esse Setor!!");
            }

            _repositorioSetor.Deletar(setor);
        }
    }
}
