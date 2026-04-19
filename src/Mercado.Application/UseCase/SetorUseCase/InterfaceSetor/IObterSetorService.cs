using Mercado.Application.Dtos.SetorDto;

namespace Mercado.Application.UseCase.SetorUseCase.InterfaceSetor
{
    public interface IObterSetorService
    {
        public Task<ObterSetorDto> ObterTodosOsSetoresPorId(Guid id);
        public Task<IEnumerable<ObterSetorDto>> ObterTodosOsSetores();
    }
}
