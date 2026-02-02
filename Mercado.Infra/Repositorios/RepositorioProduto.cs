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
    public class RepositorioProduto : IRepositorioProduto
    {
        private MercadoContext _context;

        public RepositorioProduto(MercadoContext context)
        {
            this._context = context;
        }
        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public IEnumerable<Produto> BuscarPorCategoriaId(Guid id)
        {
            return _context.Produtos.Where(p => p.CategoriaId == id).ToList();
        }

        public Produto BuscarPorCodigoDeBarras(long codigoDeBarras)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.CodigoDeBarras == codigoDeBarras);

            if(produto == null)
            {
                return null;
            }

            return produto;
        }

        public Produto BuscarPorId(Guid id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return null;
            }

            return produto;
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            return _context.Produtos.ToList();
        }

        public void Deletar(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public void Salvar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
    }
}
