using Mercado.Application.Dtos.SetorDto;

namespace Mercado.Application.UseCase.SetorUseCase.InterfaceSetor
{
    public interface IAtualizarSetorService
    {
        public SetorResponseDto Executar(Guid id, AtualizarSetorDto dto);
    }
}
