using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class ICriarCategoriaService
    {
        private IRepositorioCategoria _repositoroCategoria;
        private IRepositorioSetor _repositorioSetor;

        public ICriarCategoriaService(IRepositorioCategoria repositoroCategoria, IRepositorioSetor repositorioSetor)
        {
            this._repositoroCategoria = repositoroCategoria;
            this._repositorioSetor = repositorioSetor;
        }

        public void Executar(CriarCategoriaDto dto)
        {
            Setor setor = _repositorioSetor.BuscarPorId(dto.SetorId);

            if (setor == null)
            {
                throw new Exception("Setor Nao existe");
            }

            Categoria categoria = new Categoria(dto.Nome, dto.Descricao, dto.SetorId);

            _repositoroCategoria.Salvar(categoria);
        }
    }
}

