using Mercado.Application.Dtos.SetorDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.SetorUseCase.InterfaceSetor
{
    public interface IDeletarSetorService
    {
        public Task<SetorResponseDto> Executar(Guid id);
    }
}
