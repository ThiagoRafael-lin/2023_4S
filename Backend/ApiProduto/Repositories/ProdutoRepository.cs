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


        public void Atualizar(Produto produto, Guid id)
        {
            try
            {
                var produtoBuscado = ctx.Produtos.FirstOrDefault(x => x.IdProduct == id);
                if (produtoBuscado != null)
                {
                    produtoBuscado.Name = produto.Name;
                    produtoBuscado.Price = produto.Price;

                    ctx.Produtos.Update(produto);

                    ctx.SaveChanges();
                };
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                var produtoBuscado = ctx.Produtos.FirstOrDefault(x => x.IdProduct == id);
                return produtoBuscado ?? null!;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Cadastrar(Produto produto)
        {
            try
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                var produtoBuscado = ctx.Produtos.FirstOrDefault(x => x.IdProduct == id);
                ctx.Produtos.Remove(produtoBuscado!);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Produto> ListarTodos()
        {
            try
            {
                var listaProdutos = ctx.Produtos.ToList();
                return listaProdutos;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
