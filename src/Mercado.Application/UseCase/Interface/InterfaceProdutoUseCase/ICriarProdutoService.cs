using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public interface ICriarProdutoService
    {
        public ProdutoResponseDto Executar(CriarProdutoDto dto);
    }
}
