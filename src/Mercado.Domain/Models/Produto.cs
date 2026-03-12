namespace Mercado.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco {  get; private set; }
        public int Quantidade { get; private set; }
        public string Descricao { get; private set; }
        public string Marca {  get; private set; }
        public long CodigoDeBarras {  get; private set; }
        public DateOnly Validade { get; private set; }
        public DateOnly DataDeCriacao {  get; private set; }
        public DateOnly DataDeModificaçao { get; private set; }

        public Guid CategoriaId { get; private set; }

        public Categoria Categoria { get; private set; }


        public Produto(string nome, decimal preco, int quantidade, string descricao, string marca, long codigoDeBarras, DateOnly validade, Guid categoriaId)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Preco = preco;
            this.Quantidade = quantidade;
            this.Descricao = descricao;
            this.Marca = marca;
            this.CodigoDeBarras = codigoDeBarras;
            this.Validade = validade;
            this.DataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
            this.CategoriaId = categoriaId;
        }


        public void ModificarParaAtualizar(decimal preco, int quantidade)
        {
            this.Preco = preco;
            this.Quantidade = quantidade;

            this.DataDeModificaçao = DateOnly.FromDateTime(DateTime.Now);
        }

        public void ProdutoVendido(int NovaQuantidade)
        {
            Quantidade = Quantidade - NovaQuantidade;
        }

    }
}
