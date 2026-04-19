using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using Mercado.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Infra.Repositorios
{
    public class PostgresRepositorioSetor : IRepositorioSetor
    {
        private readonly MercadoContext _context;

        public PostgresRepositorioSetor(MercadoContext context)
        {
            this._context = context;
        }
        public async Task<Setor> Atualizar(Setor setor)
        {
            try
            {
                _context.Setores.Update(setor);
                await _context.SaveChangesAsync();

                return setor;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao Atualizar no banco de dados", ex);
            }
            
        }

        public async Task<Setor> BuscarPorId(Guid id)
        {
            try
            {
                return await _context.Setores.FindAsync(id);
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao retornar Setor", ex);
            }
            
        }

        public async Task<IEnumerable<Setor>> BuscarTodos()
        {
            try
            {
                return await _context.Setores.ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao retornat lista de Setor", ex);
            }
            
        }

        public async Task<Setor> Deletar(Setor setor)
        {
            try
            {
                _context.Setores.Remove(setor);
                await _context.SaveChangesAsync();

                return setor;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Deletar no banco de dados", ex);
            }
           
        }

        public async Task<Setor> Salvar(Setor setor)
        {
            try
            {
                _context.Setores.Add(setor);
                await _context.SaveChangesAsync();

                return setor;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Salvar no banco de dados", ex);
            }
            
        }
    }
}
