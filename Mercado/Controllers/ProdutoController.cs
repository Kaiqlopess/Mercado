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
        private DeletarProdutoService _deletarService;
        private AtualizarProdutoService _atualizarService;
        public ProdutoController(CriarProdutoService criarService, ObterProdutoService obterService, DeletarProdutoService deletarService, AtualizarProdutoService atualizarService) 
        {
            this._criarService = criarService;
            this._obterService = obterService;
            this._deletarService = deletarService;
            this._atualizarService = atualizarService;
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
            _deletarService.Executar(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(Guid id, [FromBody] AtualizarProdutoDto dto)
        {
            _atualizarService.Executar(id, dto);

            return Ok();
        }


    }
}
