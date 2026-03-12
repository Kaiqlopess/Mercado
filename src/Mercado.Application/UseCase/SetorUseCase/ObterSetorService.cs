using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase.InterfaceSetor;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class ObterSetorService : IObterSetorService
    {
        private readonly IRepositorioSetor _repositorioSetor;
        public ObterSetorService(IRepositorioSetor repositorioSetor) 
        {
            this._repositorioSetor = repositorioSetor;
        }

        public ObterSetorDto ObterTodosOsSetoresPorId(Guid id)
        {
            try
            {
                Setor setor = _repositorioSetor.BuscarPorId(id);

                if (setor == null)
                {
                    throw new Exception("Setor nao existe");
                }

                ObterSetorDto dto = new ObterSetorDto
                {
                    Nome = setor.Nome,
                    Id = setor.Id,
                };

                return dto;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao realizar a operaçao de retornar um setor", ex);
            }
            
        }

        public IEnumerable<ObterSetorDto> ObterTodosOsSetores()
        {
            try 
            {
                IEnumerable<Setor> setor = _repositorioSetor.BuscarTodos();

                var dtos = setor.Select(s => new ObterSetorDto
                {
                    Nome = s.Nome,
                    Id = s.Id,
                });

                return dtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao realizar a operaçao de retornar uma lista de setor", ex);
            }
            
        }
    }
}
