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

        public CategoriaController(CriarCategoriaService criarCategoriaService)
        {
            this._criarCategoriaService = criarCategoriaService;   
        }

        [HttpPost]
        public IActionResult CriarCategoria(CriarCategoriaDto dto)
        {
            _criarCategoriaService.Executar(dto);

            return Ok(dto);
        }
    }
}
