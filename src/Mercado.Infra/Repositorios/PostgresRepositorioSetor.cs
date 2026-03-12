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
        public Setor Atualizar(Setor setor)
        {
            try
            {
                _context.Setores.Update(setor);
                _context.SaveChanges();

                return setor;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao Atualizar no banco de dados", ex);
            }
            
        }

        public Setor BuscarPorId(Guid id)
        {
            try
            {
                return _context.Setores.Find(id);
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao retornar Setor", ex);
            }
            
        }

        public IEnumerable<Setor> BuscarTodos()
        {
            try
            {
                return _context.Setores.ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception("Erro ao retornat lista de Setor", ex);
            }
            
        }

        public Setor Deletar(Setor setor)
        {
            try
            {
                _context.Setores.Remove(setor);
                _context.SaveChanges();

                return setor;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Deletar no banco de dados", ex);
            }
           
        }

        public Setor Salvar(Setor setor)
        {
            try
            {
                _context.Setores.Add(setor);
                _context.SaveChanges();

                return setor;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Salvar no banco de dados", ex);
            }
            
        }
    }
}
