using Mercado.Domain.Interfaces.Repositorio;
using Mercado.Domain.Models;
using Mercado.Infra.Context;

namespace Mercado.Infra.Repositorios
{
    public class PostgresRepositorioProduto : IRepositorioProduto
    {
        private MercadoContext _context;

        public PostgresRepositorioProduto(MercadoContext context)
        {
            this._context = context;
        }
        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public IEnumerable<Produto> BuscarPorCategoriaId(Guid id)
        {
            return _context.Produtos.Where(p => p.CategoriaId == id).ToList();
        }

        public Produto BuscarPorCodigoDeBarras(long codigoDeBarras)
        {
            Produto produto = _context.Produtos.FirstOrDefault(p => p.CodigoDeBarras == codigoDeBarras);

            if(produto == null)
            {
                return null;
            }

            return produto;
        }

        public Produto BuscarPorId(Guid id)
        {
            Produto produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return null;
            }

            return produto;
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            return _context.Produtos.ToList();
        }

        public void Deletar(Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public Produto Salvar(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return produto;
            }
            catch (Exception ex) {
                throw new Exception($"{ex.Message}, Erro ao salvar no banco de dados");
            }
        }
    }
}
