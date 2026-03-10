using Mercado.Application.Dtos.SetorDto;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public interface IObterSetorService
    {
        public ObterSetorDto ObterTodosOsSetoresPorId(Guid id);
        public IEnumerable<ObterSetorDto> ObterTodosOsSetores();
    }
}
