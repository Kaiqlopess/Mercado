using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Application.Dtos.ProdutoDto
{
    public class ObterProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public long CodigoDeBarras { get; set; }
        public DateOnly Validade { get; set; }
        public DateOnly DataDeCriacao { get; set; }
    }
}
