using ApiProduto.Domains;
using ApiProduto.Interfaces;
using ApiProduto.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testeApiProduct
{
    public class ProdutoTest
    {
        [Fact]

        public void Get()
        {
            //Arrange

            //Lista de produtos
            List<Produto> productList = new List<Produto>
            {
                new Produto {IdProduct = Guid.NewGuid(), Name ="Produto 1", Price= 78},
                new Produto {IdProduct = Guid.NewGuid(), Name ="Produto 2", Price= 90},
                new Produto {IdProduct = Guid.NewGuid(), Name ="Produto 3", Price= 787},
            };

            //Cria um objeto de simulação do tipo IProdutoRepository
            var mockRepository = new Mock<IProdutoRepository>();

            //Configura o método "ListarTodos' para que quando for adicionado retorne a lista mockada
            mockRepository.Setup(x => x.ListarTodos()).Returns(productList);

            //Act

            //Executando o método "ListarTodos" e atribue a resposta em result
            var result = mockRepository.Object.ListarTodos();

            //Assert

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Post()
        {
            // ARRANGE

            //Cria um novo objeto produto
            var novoProduto = new Produto
            {
                IdProduct = Guid.NewGuid(),
                Name = "Novo Produto",
                Price = 100
            };

            //Criar uma lista
            List<Produto> productList = new List<Produto>();

            //Cria um objeto de simulação do tipo IProdutoRepository
            var mockRepository = new Mock<IProdutoRepository>();

            //.Setup accesa os metodos dentro o Mock
            mockRepository.Setup(x => x.Cadastrar(novoProduto)).Callback<Produto>(x => productList.Add(novoProduto));

            //mockRepository.Setup(x => x.Cadastrar(It.IsAny<Produto>())); - outra maneira de fazer

            // ACT

            mockRepository.Object.Cadastrar(novoProduto);

            // ASSERT
            Assert.Contains(novoProduto, productList);


            //mockRepository.Verify(x => x.Cadastrar(novoProduto), Times.Once); - outra maneira de fazer
        }

        [Fact]

        public void GetById()
        {
            //ARRANGE

            //instancia um novo Id
            Guid BuscarProIdProduto = Guid.NewGuid();

            //Cria um objeto de simulação do tipo IProdutoRepository
            var mockRepository = new Mock<IProdutoRepository>();

            //Cria uma lista para atualizar o Id
            var ListaProdutoProcurar = new Produto
            {
                IdProduct = Guid.NewGuid(),
                Name = "Caixa de Leite",
                Price = 20
            };

            //Logica para acessar a lista e atualizar o Id e retornar a lista atualizada
            mockRepository.Setup(x => x.BuscarPorId(BuscarProIdProduto)).Returns(ListaProdutoProcurar);


            //ACT

            var produtoAchado = mockRepository.Object.BuscarPorId(BuscarProIdProduto);


            //ASSERT

            Assert.NotNull(produtoAchado);
            //Assert.Equal(BuscarProIdProduto, produtoAchado.IdProduct);
            //Assert.Equal("Caixa de Leite", produtoAchado.Name);
            //Assert.Equal(20, produtoAchado.Price);

        }

        [Fact]

        public void Delete()
        {
            //ARRANGE

            Guid DeletarPorId = Guid.NewGuid();

            var mockRepository = new Mock<IProdutoRepository>();

            var ListaProdutoDeletar = new Produto
            {
                IdProduct = Guid.NewGuid(),
                Name = "Caixa de Leite",
                Price = 30
            };

            //ACT

            mockRepository.Object.Deletar(DeletarPorId);


            //ASSERT

            mockRepository.Verify(r => r.Deletar(DeletarPorId), Times.Once);
        }

        [Fact]
        public void Put()
        {

            //  ARRANGE
            Guid AtualizarPorId = Guid.NewGuid();

            var mockRepository = new Mock<IProdutoRepository>();

            var ListaProdutoAtualizar = new Produto
            {
                IdProduct = AtualizarPorId,
                Name = "Caixa de Leite desnatado",
                Price = 30
            };

            //ACT

            mockRepository.Object.Atualizar(ListaProdutoAtualizar);


            //ASSERT


            mockRepository.Verify(a => a.Atualizar(It.Is<Produto>(p => p.IdProduct == AtualizarPorId)));
        }
    }
}
