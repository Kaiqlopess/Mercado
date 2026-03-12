namespace Mercado.Application.Dtos.CategoriaDto
{
    public class CriarCategoriaDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Guid SetorId { get; set; }

    }
}
