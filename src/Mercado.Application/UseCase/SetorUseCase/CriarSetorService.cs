using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase.InterfaceSetor;
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

        public async Task<SetorResponseDto> Executar(CriarSetorDto dto)
        {
            try
            {
                Setor setor = new Setor(dto.Nome, dto.Descricao);

                Setor setorCriado = await _repositorio.Salvar(setor);

                SetorResponseDto response = new SetorResponseDto() { Id = setorCriado.Id, Nome = setorCriado.Nome, Descriçao = setorCriado.Descricao};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao de Inserir!", ex);
            }
           
        }
    }
}
