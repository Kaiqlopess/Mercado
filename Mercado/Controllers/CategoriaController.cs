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
            _criarCategoriaService.Executar(dto);

            return Ok(dto);
        }

        [HttpGet]

        public IActionResult Listar() 
        {
            return Ok(_obterCategoriaService.ObrterTodasAsCategorias());
        }

        [HttpDelete("{id}")]
        public IActionResult DeletandoCategoria(Guid id) 
        {
            _deletarCategoriaService.Executar(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizandoCategoria(Guid id, [FromBody] AtualizarCategoriaDto dto)
        {
            _atualizarCategoriaService.Executar(id, dto);

            return Ok();
        }


    }
}
