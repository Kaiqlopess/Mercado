using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetorController : ControllerBase
    {
        private ICriarSetorService _setorService;
        private IObterSetorService _obterService;
        private IDeletarSetorService _deleteService;
        private IAtualizarSetorService _atualizarSetor;
        public SetorController(ICriarSetorService setorService, IObterSetorService obterService, IDeletarSetorService deleteService, IAtualizarSetorService atualizarSetor)
        {
            this._setorService = setorService;
            this._obterService = obterService;
            this._deleteService = deleteService;
            this._atualizarSetor = atualizarSetor;
        }

        [HttpPost]
        public IActionResult CriarSetor(CriarSetorDto dto)
        {
            try
            {
                _setorService.Executar(dto);
                return Ok(dto);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ObterSetores()
        {
            try
            {
                return Ok(_obterService.ObterTodosOsSetores());
            }
            catch (Exception ex) 
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSetor(Guid id)
        {
            try
            {
                _deleteService.Executar(id);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(new { mensagem = ex.Message });  
            }
                

           
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSetor(Guid id, [FromBody] AtualizarSetorDto dto)
        {

            try
            {
                _atualizarSetor.Executar(id, dto);
                return Ok(dto);
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }


    }
}
