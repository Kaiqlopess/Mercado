



using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public interface IProdutoVendidoNoCaixaService
    {
        public void Executar(long codigoDeBarras, int quantidade);

    }
}
