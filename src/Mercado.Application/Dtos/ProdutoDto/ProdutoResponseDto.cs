using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.Dtos.ProdutoDto
{
    public class ProdutoResponseDto
    {
       public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
