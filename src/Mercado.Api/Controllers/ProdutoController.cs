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
        public IActionResult CriarProduto([FromBody] CriarProdutoDto dto) 
        {
            try
            {
                ProdutoResponseDto produto = _criarService.Executar(dto);    
                return Ok(produto);
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

        [HttpGet("categoria/{id}")]
        public IActionResult ListarProdutosPorCategoriaId(Guid id)
        {
            try
            {
                return Ok(_obterService.ObterProdutosPorCategoriaId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(Guid id) 
        {
            try
            {
                ProdutoResponseDto response = _deletarService.Executar(id);
                return Ok(response);
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
                ProdutoResponseDto response = _atualizarService.Executar(id, dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message});
            }  
        }

        [HttpPost("vender")]
        public IActionResult ProdutoVendido([FromBody] ProdutoVendidoDto dto)
        {
            try
            {
                ProdutoResponseDto response = _produtoVendidoNoCaixa.Executar(dto.CodigoDeBarras, dto.Quantidade);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
           
        }


    }
}
