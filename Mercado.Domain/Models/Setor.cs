using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Models
{
    public class Setor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateOnly DataDeCriacao { get; private set; }
        public DateOnly DataDeModificaçao { get; private set; }

        public Setor(string nome, string descricao)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Descricao = descricao;
            this.DataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
            
        }

    }
}
