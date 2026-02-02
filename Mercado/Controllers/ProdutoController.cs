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
            try
            {
                _criarService.Executar(dto);
                return Ok(dto);
            }
            catch (Exception ex) 
            {
                return BadRequest(new {mensagem = ex.Message});
            }
          
        }

        [HttpGet]
        public IActionResult ListarTodosOsProduto()
        {
            try
            {
                return Ok(_obterService.ObterTodosOsProdutos());
            }
            catch (Exception ex) 
            {
                return BadRequest(new {mensagem = ex.Message});
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(Guid id) 
        {
            try
            {
                _deletarService.Executar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {mensagem = ex.Message});
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(Guid id, [FromBody] AtualizarProdutoDto dto)
        {
            try
            {
                _atualizarService.Executar(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message});
            }  
        }


    }
}
