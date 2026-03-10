using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public interface IObterProdutoService
    {
        public IEnumerable<ObterProdutoDto> ObterTodosOsProdutos();
        public IEnumerable<ObterProdutoDto> ObterProdutosPorCategoriaId(Guid id);
        public ObterProdutoDto ObterProdutosPorId(Guid id);
        public ObterProdutoDto ObterProdutosPorCodigoDeBarras(long codigoDeBarras);
    }
}
