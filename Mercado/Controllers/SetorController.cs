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
        private DeletarSetorService _deleteService;
        private AtualizarSetorService _atualizarSetor;
        public SetorController(CriarSetorService setorService, ObterSetorService obterService, DeletarSetorService deleteService, AtualizarSetorService atualizarSetor)
        {
            this._setorService = setorService;
            this._obterService = obterService;
            this._deleteService = deleteService;
            this._atualizarSetor = atualizarSetor;
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

        [HttpDelete("{id}")]
        public IActionResult DeletarSetor(Guid id)
        {
            _deleteService.Executar(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarSetor(Guid id, [FromBody] AtualizarSetorDto dto)
        {
            _atualizarSetor.Executar(id, dto);

            return Ok(dto);
        }


    }
}
