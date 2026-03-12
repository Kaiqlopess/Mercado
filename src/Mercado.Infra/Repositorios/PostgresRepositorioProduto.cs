using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using Mercado.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Infra.Repositorios
{
    public class PostgresRepositorioProduto : IRepositorioProduto
    {
        private readonly MercadoContext _context;

        public PostgresRepositorioProduto(MercadoContext context)
        {
            this._context = context;
        }
        public Produto Atualizar(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();

                return produto;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Atualizar no banco de dados", ex);
            }
        }

        public IEnumerable<Produto> BuscarPorCategoriaId(Guid id)
        {
            try
            {
                return _context.Produtos.Where(p => p.CategoriaId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar lista do banco de dados", ex);
            }
            
        }

        public Produto BuscarPorCodigoDeBarras(long codigoDeBarras)
        {

            try
            {
                return _context.Produtos.FirstOrDefault(p => p.CodigoDeBarras == codigoDeBarras);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar produto do banco de dados", ex);
            }
            
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _context.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar produto do banco de dados");
            }
            
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            try
            {
                return _context.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar lista do banco de dados");
            }
            
        }

        public Produto Deletar(Produto produto)
        {
            try
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return produto;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao Deletar no banco de dados", ex);
            }
        }

        public Produto Salvar(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

               return produto;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao salvar no banco de dados", ex);
            }
        }

       
    }
}
