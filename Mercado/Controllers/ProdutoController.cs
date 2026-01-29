using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private CriarProdutoService _criarService;
        private ObterProdutoService _obterService;
        private DeletarProdutoService _deletarProdutoService;
        public ProdutoController(CriarProdutoService criarService, ObterProdutoService obterService, DeletarProdutoService deletarProdutoService) 
        {
            this._criarService = criarService;
            this._obterService = obterService;
            this._deletarProdutoService = deletarProdutoService;
        }

        [HttpPost]
        public IActionResult CriarProduto([FromBody] CriarProdutoDto dto) 
        {
            _criarService.Executar(dto);

            return Ok(dto);
        }

        [HttpGet]
        public IActionResult ListarTodosOsProduto()
        {
            return Ok(_obterService.ObterTodosOsProdutos());
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(Guid id) 
        {
            _deletarProdutoService.Executar(id);

            return Ok();
        }

    }
}
