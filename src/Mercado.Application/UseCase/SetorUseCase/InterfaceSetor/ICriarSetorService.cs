using Mercado.Application.Dtos.SetorDto;

namespace Mercado.Application.UseCase.SetorUseCase.InterfaceSetor
{
    public interface ICriarSetorService
    {
        public SetorResponseDto Executar(CriarSetorDto dto);
    }
}
