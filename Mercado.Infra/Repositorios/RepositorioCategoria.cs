using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using Mercado.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Infra.Repositorios
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private MercadoContext _context;

        public RepositorioCategoria(MercadoContext context)
        {
            this._context = context;
        }
        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public Categoria BuscarPorId(Guid id)
        {
            var categoria = _context.Categorias.Find(id);

            if (categoria == null) 
            {
                return null;
            }

            return categoria;
        }

        public IEnumerable<Categoria> BuscarPorSetorId(Guid id)
        {
            return _context.Categorias.Where(c => c.SetorId == id).ToList(); ;
        }

        public void Deletar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

        public void Salvar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }
    }
}
