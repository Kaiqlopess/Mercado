using Mercado.Application.Dtos.SetorDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class CriarSetorService : ICriarSetorService
    {
        private IRepositorioSetor _repositorio;
        public CriarSetorService(IRepositorioSetor repositorio)
        {
            this._repositorio = repositorio;           
        }

        public void Executar(CriarSetorDto dto)
        {
            Setor setor = new Setor(dto.Nome, dto.Descricao);

            _repositorio.Salvar(setor);
        }
    }
}
