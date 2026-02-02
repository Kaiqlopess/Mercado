using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.Dtos.SetorDto;
using Mercado.Domain.Interfaces.Repositorio;
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
            var setor = _repositorioSetor.BuscarPorId(id);

            if (setor == null)
            {
                throw new Exception("Setor nao existe");
            }

            var dto = new ObterSetorDto
            {
                Nome = setor.Nome,
                Descricao = setor.Descricao,
            };

            return dto;
        }

        public IEnumerable<ObterSetorDto> ObterTodosOsSetores()
        {
            var setor = _repositorioSetor.BuscarTodos();

            var dtos = setor.Select(c => new ObterSetorDto
            {
                Nome = c.Nome,
                Descricao = c.Descricao
            });

            return dtos;

        }
    }
}
