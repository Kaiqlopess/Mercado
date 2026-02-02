using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.UseCase.CategoriaUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private CriarCategoriaService _criarCategoriaService;
        private ObterCategoriaService _obterCategoriaService;
        private DeletarCategoriaService _deletarCategoriaService;
        private AtualizarCategoriaService _atualizarCategoriaService;

        public CategoriaController(CriarCategoriaService criarCategoriaService, ObterCategoriaService obterCategoriaService, DeletarCategoriaService deletarCategoriaService, AtualizarCategoriaService atualizarCategoria)
        {
            this._criarCategoriaService = criarCategoriaService;   
            this._obterCategoriaService = obterCategoriaService;
            this._deletarCategoriaService = deletarCategoriaService;
            this._atualizarCategoriaService = atualizarCategoria;
        }

        [HttpPost]
        public IActionResult CriandoCategoria(CriarCategoriaDto dto)
        {
            try
            {
                _criarCategoriaService.Executar(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message});
            }

            
        }

        [HttpGet]

        public IActionResult Listar() 
        {
            try
            {
                return Ok(_obterCategoriaService.ObrterTodasAsCategorias());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult DeletandoCategoria(Guid id) 
        {
            try
            {
                _deletarCategoriaService.Executar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult AtualizandoCategoria(Guid id, [FromBody] AtualizarCategoriaDto dto)
        {
            try
            {
                _atualizarCategoriaService.Executar(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }


    }
}
