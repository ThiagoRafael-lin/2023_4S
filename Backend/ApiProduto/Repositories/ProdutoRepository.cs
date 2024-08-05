using ApiProduto.Contexts;
using ApiProduto.Controllers;
using ApiProduto.Domains;
using ApiProduto.Interfaces;

namespace ApiProduto.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ProdutoContext ctx;


        public ProdutoRepository()
        {
            ctx = new ProdutoContext();
        }


        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
