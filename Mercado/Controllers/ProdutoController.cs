using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private CriarProdutoService _produtoService;
        public ProdutoController(CriarProdutoService produtoService) 
        {
            this._produtoService = produtoService;
        }

        [HttpPost]
        public IActionResult CriarProduto(CriarProdutoDto dto) 
        {
            _produtoService.Executar(dto);

            return Ok(dto);
        }
    }
}
