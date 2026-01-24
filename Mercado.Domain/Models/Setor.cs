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

        public Setor(string name, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = name;
            Descricao = descricao;
            DataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
            
        }

    }
}
