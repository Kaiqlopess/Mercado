using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using Mercado.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Infra.Repositorios
{
    public class PostgresRepositorioSetor : IRepositorioSetor
    {
        private MercadoContext _context;

        public PostgresRepositorioSetor(MercadoContext context)
        {
            _context = context;
        }
        public void Atualizar(Setor setor)
        {
            _context.Setores.Update(setor);
            _context.SaveChanges();
        }

        public Setor BuscarPorId(Guid id)
        {
            Setor setor = _context.Setores.Find(id);

            if (setor == null) 
            {
                return null;
            }

            return setor;
        }

        public IEnumerable<Setor> BuscarTodos()
        {
            return _context.Setores.ToList();
        }

        public void Deletar(Setor setor)
        {
            _context.Setores.Remove(setor);
            _context.SaveChanges();
        }

        public void Salvar(Setor setor)
        {
            _context.Setores.Add(setor);
            _context.SaveChanges();
        }
    }
}
