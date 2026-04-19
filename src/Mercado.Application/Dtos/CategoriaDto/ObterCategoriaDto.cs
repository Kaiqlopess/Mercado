namespace Mercado.Application.Dtos.CategoriaDto
{
    public class ObterCategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Guid SetorId { get; set; }
        public string SetorNome {  get; set; }

    }
}
