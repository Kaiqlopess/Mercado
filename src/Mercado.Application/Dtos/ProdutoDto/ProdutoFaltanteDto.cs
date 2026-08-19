namespace Mercado.Application.Dtos.ProdutoDto
{
    public class ProdutoFaltanteDto
    {
        public string Nome { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public int SugestaoCompra { get; set; }
    }
}
