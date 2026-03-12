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
        public Categoria Atualizar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();

                return categoria;
            }
            catch (DbUpdateException ex) 
            {
                throw new Exception("Erro ao Atualizar no banco de dados", ex);
            }
            
        }

        public Categoria BuscarPorId(Guid id)
        {
            try
            {       
                return _context.Categorias.Find(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao Retornar Categoria do banco de dados", ex);
            }
            
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            try
            {
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar Lista do banco de dados", ex);
            }
           
        }

        public IEnumerable<Categoria> BuscarPorSetorId(Guid id)
        {
            try
            {
                return _context.Categorias.Where(c => c.SetorId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Retornar Lista do banco de dados", ex);
            }
            
        }

        public Categoria Deletar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return categoria;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Deletar no banco de dados", ex);
            }
            
        }

        public Categoria Salvar(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return categoria;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Erro ao Salvar no banco de dados", ex);
            }
            
        }
    }
}
