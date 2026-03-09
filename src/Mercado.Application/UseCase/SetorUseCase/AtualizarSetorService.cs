using Mercado.Application.Dtos.SetorDto;
using Mercado.Domain.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.SetorUseCase
{
    public class AtualizarSetorService
    {
        private IRepositorioSetor _repositorioSetor;
        public AtualizarSetorService(IRepositorioSetor repositorioSetor)
        {
            this._repositorioSetor = repositorioSetor;
        }

        public void Executar(Guid id, AtualizarSetorDto dto)
        {
            var setor = _repositorioSetor.BuscarPorId(id);

            if(setor == null)
            {
                throw new Exception("Setor nao encontrado");
            }

            setor.Modificar(dto.Nome, dto.Descricao);

            _repositorioSetor.Atualizar(setor);
        }
    }
}
