using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public interface IAtualizarProdutoService
    {
        void Executar(Guid id, AtualizarProdutoDto dto);
    }
}
