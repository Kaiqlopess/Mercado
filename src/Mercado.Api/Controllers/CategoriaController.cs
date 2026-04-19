using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICriarCategoriaService _criarCategoriaService;
        private readonly IObterCategoriaService _obterCategoriaService;
        private readonly IDeletarCategoriaService _deletarCategoriaService;
        private readonly IAtualizarCategoriaService _atualizarCategoriaService;

        public CategoriaController(ICriarCategoriaService criarCategoriaService, IObterCategoriaService obterCategoriaService, IDeletarCategoriaService deletarCategoriaService, IAtualizarCategoriaService atualizarCategoria)
        {
            this._criarCategoriaService = criarCategoriaService;   
            this._obterCategoriaService = obterCategoriaService;
            this._deletarCategoriaService = deletarCategoriaService;
            this._atualizarCategoriaService = atualizarCategoria;
        }

        [HttpPost]
        public async Task<IActionResult> CriandoCategoria(CriarCategoriaDto dto)
        {
            try
            {
                CategoriaResponseDto response = await _criarCategoriaService.Executar(dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message});
            }
        
        }

        [HttpGet]
        public async Task<IActionResult> Listar() 
        {
            try
            {
                return Ok(await _obterCategoriaService.ObterTodasAsCategorias());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletandoCategoria(Guid id) 
        {
            try
            {
                CategoriaResponseDto response = await _deletarCategoriaService.Executar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizandoCategoria(Guid id, [FromBody] AtualizarCategoriaDto dto)
        {
            try
            {
                CategoriaResponseDto response = await _atualizarCategoriaService.Executar(id, dto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }
    }
}
