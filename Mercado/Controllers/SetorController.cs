using Mercado.Application.Dtos.SetorDto;
using Mercado.Application.UseCase.SetorUseCase;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetorController : ControllerBase
    {
        private CriarSetorService _setorService;
        private ObterSetorService _obterService;
        public SetorController(CriarSetorService setorService, ObterSetorService obterService)
        {
            this._setorService = setorService;
            this._obterService = obterService;
        }

        [HttpPost]
        public IActionResult CriarSetor(CriarSetorDto dto)
        {
            _setorService.Executar(dto);

            return Ok(dto); 
        }

        [HttpGet]
        public IActionResult ObterSetor()
        {
            return Ok(_obterService.ObterTodosOsSetores());
        }

        [HttpDelete]
        public IActionResult DeletarSetor()
        {

            return Ok();
        }


    }
}
