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
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
            Descricao = descricao;
            Marca = marca;
            CodigoDeBarras = codigoDeBarras;
            Validade = validade;
            DataDeCriacao = DateOnly.FromDateTime(DateTime.Now);
            CategoriaId = categoriaId;
        }


        public void Modificar(decimal preco, int quantidade)
        {
            Preco = preco;
            Quantidade = quantidade;

            DataDeModificaçao = DateOnly.FromDateTime(DateTime.Now);
        }

    }
}
