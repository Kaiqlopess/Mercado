using Mercado.Application.Dtos.ProdutoDto;
using Mercado.Application.UseCase.ProdutoUseCase.InterfaceProduto;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ICriarProdutoService _criarService;
        private readonly IObterProdutoService _obterService;
        private readonly IDeletarProdutoService _deletarService;
        private readonly IAtualizarProdutoService _atualizarService;
        private readonly IProdutoVendidoNoCaixaService _produtoVendidoNoCaixa;
        public ProdutoController(ICriarProdutoService criarService, IObterProdutoService obterService, IDeletarProdutoService deletarService, IAtualizarProdutoService atualizarService, IProdutoVendidoNoCaixaService produtoVendidoNoCaixa) 
        {
            this._criarService = criarService;
            this._obterService = obterService;
            this._deletarService = deletarService;
            this._atualizarService = atualizarService;
            this._produtoVendidoNoCaixa = produtoVendidoNoCaixa;
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoDto dto) 
        {
            try
            {
                ProdutoResponseDto produto = await _criarService.Executar(dto);    
                return Ok(produto);
            }
            catch (Exception ex) 
            {
                return BadRequest(new {mensagem = ex.Message});
            }
          
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosOsProduto()
        {
            try
            {
                return Ok(await _obterService.ObterTodosOsProdutos());
            }
            catch (Exception ex) 
            {
                return BadRequest(new {mensagem = ex.Message});
            }
            
        }

        [HttpGet("categoria/{id}")]
        public async Task<IActionResult> ListarProdutosPorCategoriaId(Guid id)
        {
            try
            {
                return Ok(await _obterService.ObterProdutosPorCategoriaId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(Guid id) 
        {
            try
            {
                ProdutoResponseDto response = await _deletarService.Executar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new {mensagem = ex.Message});
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(Guid id, [FromBody] AtualizarProdutoDto dto)
        {
            try
            {
                ProdutoResponseDto response = await _atualizarService.Executar(id, dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message});
            }  
        }

        [HttpPost("vender")]
        public async Task<IActionResult> ProdutoVendido([FromBody] ProdutoVendidoDto dto)
        {
            try
            {
                ProdutoResponseDto response = await _produtoVendidoNoCaixa.Executar(dto.CodigoDeBarras, dto.Quantidade);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
           
        }


    }
}
