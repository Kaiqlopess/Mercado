using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Application.UseCase.CategoriaUseCase.InterfaceCategoria;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class CriarCategoriaService : ICriarCategoriaService
    {
        private readonly IRepositorioCategoria _repositoroCategoria;
        private readonly IRepositorioSetor _repositorioSetor;

        public CriarCategoriaService(IRepositorioCategoria repositoroCategoria, IRepositorioSetor repositorioSetor)
        {
            this._repositoroCategoria = repositoroCategoria;
            this._repositorioSetor = repositorioSetor;
        }

        public CategoriaResponseDto Executar(CriarCategoriaDto dto)
        {
            try
            {
                Setor setor = _repositorioSetor.BuscarPorId(dto.SetorId);

                if (setor == null)
                {
                    throw new Exception("Setor Nao existe");
                }

                Categoria categoria = new Categoria(dto.Nome, dto.Descricao, dto.SetorId);

                Categoria categoriaCriada = _repositoroCategoria.Salvar(categoria);

                CategoriaResponseDto response = new CategoriaResponseDto(){ Id = categoriaCriada.Id, Nome = categoriaCriada.Nome};

                return response;
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao executar a operaçao de inserir!", ex);
            }
            
        }
    }
}

