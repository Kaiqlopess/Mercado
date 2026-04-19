using Mercado.Application.Dtos.SetorDto;

namespace Mercado.Application.UseCase.SetorUseCase.InterfaceSetor
{
    public interface ICriarSetorService
    {
        public Task<SetorResponseDto> Executar(CriarSetorDto dto);
    }
}
