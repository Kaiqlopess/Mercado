using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase.InterfaceSetor;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class AtualizarSetorService : IAtualizarSetorService
    {
        private readonly IRepositorioSetor _repositorioSetor;
        public AtualizarSetorService(IRepositorioSetor repositorioSetor)
        {
            this._repositorioSetor = repositorioSetor;
        }

        public async Task<SetorResponseDto> Executar(Guid id, AtualizarSetorDto dto)
        {
            try
            {
                Setor setor = await _repositorioSetor.BuscarPorId(id);

                if (setor == null)
                {
                    throw new Exception("Setor nao encontrado");
                }

                setor.Modificar(dto.Nome, dto.Descricao);

                Setor setorAtualizado = await _repositorioSetor.Atualizar(setor);

                SetorResponseDto response = new SetorResponseDto() { Id = setorAtualizado.Id, Nome = setorAtualizado.Nome, Descriçao = setorAtualizado.Descricao};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a operaçao de Atualizar", ex);
            }
            
        }
    }
}
