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
        public async Task<Produto> Atualizar(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Atualizar no banco de dados", ex);
            }
        }

        public async Task<IEnumerable<Produto>> BuscarPorCategoriaId(Guid id)
        {
            try
            {
                return await _context.Produtos.Where(p => p.CategoriaId == id).Include(p => p.Categoria).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar lista do banco de dados", ex);
            }
            
        }

        public async Task<Produto> BuscarPorCodigoDeBarras(long codigoDeBarras)
        {

            try
            {
                return await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.CodigoDeBarras == codigoDeBarras);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar produto do banco de dados", ex);
            }
            
        }

        public async Task<Produto> BuscarPorId(Guid id)
        {
            try
            {
                return await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar produto do banco de dados", ex);
            }
            
        }

        public async Task<IEnumerable<Produto>> BuscarTodos()
        {
            try
            {
                return await _context.Produtos.Include(p => p.Categoria).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar lista do banco de dados", ex);
            }
            
        }

        public async Task<Produto> Deletar(Produto produto)
        {
            try
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao Deletar no banco de dados", ex);
            }
        }

        public async Task<Produto> Salvar(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

               return produto;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao salvar no banco de dados", ex);
            }
        }

       
    }
}
