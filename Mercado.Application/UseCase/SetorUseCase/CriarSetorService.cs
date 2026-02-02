using Mercado.Application.Dtos;
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
    public class CriarSetorService
    {
        private IRepositorioSetor _repositorio;
        public CriarSetorService(IRepositorioSetor repositorio)
        {
            this._repositorio = repositorio;           
        }

        public void Executar(CriarSetorDto dto)
        {
            var setor = new Setor(dto.Nome, dto.Descricao);

            _repositorio.Salvar(setor);
        }
    }
}
