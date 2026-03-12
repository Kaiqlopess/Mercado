using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase.InterfaceSetor;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetorController : ControllerBase
    {
        private readonly ICriarSetorService _setorService;
        private readonly IObterSetorService _obterService;
        private readonly IDeletarSetorService _deleteService;
        private readonly IAtualizarSetorService _atualizarSetor;
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
                SetorResponseDto response = _setorService.Executar(dto);
                return Ok(response);
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
                SetorResponseDto response = _deleteService.Executar(id);
                return Ok(response);
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
                SetorResponseDto response = _atualizarSetor.Executar(id, dto);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            
        }


    }
}
