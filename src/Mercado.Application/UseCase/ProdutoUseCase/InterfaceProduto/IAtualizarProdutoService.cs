using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto
{
    public interface IAtualizarProdutoService
    {
        ProdutoResponseDto Executar(Guid id, AtualizarProdutoDto dto);
    }
}
