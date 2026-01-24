using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Domain.Models
{
    public class Categoria
    {
        public Guid Id { get; private set; } 
        public string Nome {  get; private set; }
        public string Descricao {  get; private set; } 
        public DateOnly DataDeCriacao { get; private set; }
        public DateOnly DataDeModificaçao { get; private set; }
        public Guid SetorId { get; private set; }
        public Setor Setor {  get; private set; }



        public Categoria(string nome, string descricao, Guid setorId)
        {
            Id = Guid.NewGuid();    
            Nome = nome;
            Descricao = descricao;
            SetorId = setorId;
            DataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
        }

    }
}
