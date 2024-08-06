using ApiProduto.Contexts;
using ApiProduto.Controllers;
using ApiProduto.Domains;
using ApiProduto.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var produtoExistente = ctx.Produtos.Local.FirstOrDefault(p => p.IdProduct == id);

            if (produtoExistente != null)
            {
                ctx.Entry(produtoExistente).CurrentValues.SetValues(produto);
            }
            else
            {
                ctx.Produtos.Attach(produto);
            }

            ctx.SaveChanges();
        }

        public void Atualizar(Produto listaProdutoAtualizar)
        {
            throw new NotImplementedException();
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
