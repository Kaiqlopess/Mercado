using Mercado.Application.Dtos.SetorDto;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public interface IAtualizarSetorService
    {
        public void Executar(Guid id, AtualizarSetorDto dto);
    }
}
