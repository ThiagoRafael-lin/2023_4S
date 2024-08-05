using ApiProduto.Domains;


namespace ApiProduto.Interfaces

{
    public interface IProdutoRepository
    {
        public void Cadastrar(Produto produto);
        public Produto BuscarPorId (Guid id);

        public List<Produto> ListarTodos();

        void Deletar(Guid id);

        void Atualizar(Produto produto);

    }
}
