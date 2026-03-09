using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.Dtos.SetorDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class ObterSetorService
    {
        private IRepositorioSetor _repositorioSetor;
        public ObterSetorService(IRepositorioSetor repositorioSetor) 
        {
            this._repositorioSetor = repositorioSetor;
        }

        public ObterSetorDto ObterTodosOsSetoresPorId(Guid id)
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

        public IEnumerable<ObterSetorDto> ObterTodosOsSetores()
        {
            IEnumerable<Setor> setor = _repositorioSetor.BuscarTodos();

            var dtos = setor.Select(s => new ObterSetorDto
            {
                Nome = s.Nome,
                Id = s.Id,
            });

            return dtos;

        }
    }
}
