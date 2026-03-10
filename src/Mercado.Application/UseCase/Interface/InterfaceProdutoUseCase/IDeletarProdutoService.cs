using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.ProdutoUseCase
{
    public interface IDeletarProdutoService
    {
        public void Executar(Guid id);
    }
}
