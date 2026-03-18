using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase.InterfaceSetor;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class DeletarSetorService : IDeletarSetorService
    {
        private readonly IRepositorioSetor _repositorioSetor;
        private readonly IRepositorioCategoria _repositorioCategoria;
        public DeletarSetorService(IRepositorioSetor repositorioSetor, IRepositorioCategoria repositorioCategoria) 
        {
            this._repositorioSetor = repositorioSetor;
            this._repositorioCategoria = repositorioCategoria;
        }

        public SetorResponseDto Executar(Guid id)
        {
            try
            {
                Setor setor = _repositorioSetor.BuscarPorId(id);

                if (setor == null)
                {
                    throw new Exception("Setor nao encontrado");
                }

                IEnumerable<Categoria> categorias = _repositorioCategoria.BuscarPorSetorId(id);

                if (categorias.Any())
                {
                    throw new Exception("há categorias com esse Setor!!");
                }

                Setor setorDeletado = _repositorioSetor.Deletar(setor);

                SetorResponseDto response = new SetorResponseDto() { Id = setorDeletado.Id, Nome = setorDeletado.Nome, Descriçao = setorDeletado.Descricao};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao de Deletar", ex);
            }
            
        }
    }
}
