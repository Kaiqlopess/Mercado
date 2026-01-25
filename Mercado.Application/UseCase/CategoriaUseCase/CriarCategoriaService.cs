using Mercado.Application.Dtos.CategoriaDto;
using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.UseCase.CategoriaUseCase
{
    public class CriarCategoriaService
    {
        private IRepositorioCategoria _repositoroCategoria;
        private IRepositorioSetor _repositorioSetor;

        public CriarCategoriaService(IRepositorioCategoria repositoroCategoria, IRepositorioSetor repositorioSetor)
        {
            this._repositoroCategoria = repositoroCategoria;
            this._repositorioSetor = repositorioSetor;
        }

        public void Executar(CriarCategoriaDto dto)
        {
            var setor = _repositorioSetor.BuscarPorId(dto.SetorId);

            if (setor == null)
            {
                throw new Exception("Setor Nao existe");
            }

            var categoria = new Categoria(dto.Nome, dto.Descricao, dto.SetorId);

            _repositoroCategoria.Salvar(categoria);
        }
    }
}

