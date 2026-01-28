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
        public SetorController(CriarSetorService setorService)
        {
            this._setorService = setorService;
        }

        [HttpPost]
        public IActionResult CriarSetor(CriarSetorDto dto)
        {
            _setorService.Executar(dto);

            return Ok(dto); 
        }


    }
}
