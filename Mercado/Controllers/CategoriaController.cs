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

        public CategoriaController(CriarCategoriaService criarCategoriaService, ObterCategoriaService obterCategoriaService)
        {
            this._criarCategoriaService = criarCategoriaService;   
            this._obterCategoriaService = obterCategoriaService;
        }

        [HttpPost]
        public IActionResult CriarCategoria(CriarCategoriaDto dto)
        {
            _criarCategoriaService.Executar(dto);

            return Ok(dto);
        }

        [HttpGet]

        public IActionResult ListarCategorias() 
        {
            

            return Ok(_obterCategoriaService.Todos());
        }
    }
}
