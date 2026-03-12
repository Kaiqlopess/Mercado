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

        public SetorResponseDto Executar(Guid id, AtualizarSetorDto dto)
        {
            try
            {
                Setor setor = _repositorioSetor.BuscarPorId(id);

                if (setor == null)
                {
                    throw new Exception("Setor nao encontrado");
                }

                setor.Modificar(dto.Nome, dto.Descricao);

                Setor setorAtualizado = _repositorioSetor.Atualizar(setor);

                SetorResponseDto response = new SetorResponseDto() { Id = setorAtualizado.Id, Nome = setorAtualizado.Nome };

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a operaçao de Atualizar", ex);
            }
            
        }
    }
}
