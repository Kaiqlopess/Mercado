using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using Mercado.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Infra.Repositorios
{
    public class PostgresRepositorioCategoria : IRepositorioCategoria
    {
        private readonly MercadoContext _context;

        public PostgresRepositorioCategoria(MercadoContext context)
        {
            this._context = context;
        }
        public async Task<Categoria>  Atualizar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();

                return categoria;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao Atualizar no banco de dados", ex);
            }
            
        }

        public async Task<Categoria> BuscarPorId(Guid id)
        {
            try
            {       
                return await _context.Categorias.Include(c => c.Setor).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Retornar Categoria do banco de dados", ex);
            }
            
        }

        public async Task<IEnumerable<Categoria>> BuscarTodos()
        {
            try
            {
                return await _context.Categorias.Include(c => c.Setor).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar Lista do banco de dados", ex);
            }
           
        }

        public async Task<IEnumerable<Categoria>> BuscarPorSetorId(Guid id)
        {
            try
            {
                return await _context.Categorias.Where(c => c.SetorId == id).Include(c => c.Setor).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar Lista do banco de dados", ex);
            }
            
        }

        public async Task<Categoria> Deletar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return categoria;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Deletar no banco de dados", ex);
            }
            
        }

        public async Task<Categoria> Salvar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();

                return categoria;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Salvar no banco de dados", ex);
            }
            
        }
    }
}
