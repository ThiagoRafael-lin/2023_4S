using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Biblioteca;



namespace Biblioteca.Test
{
    public class BibliotecaTest
    {
        [Fact]
        public void AdicionarLivro_AdicionaCorretamente()
        {
            // Arrange
            var biblioteca = new Biblioteca();
            var livroEsperado = new Livro { Titulo = "Dom Casmurro" };

            // Act
            biblioteca.AdicionarLivro(livroEsperado);

            // Assert
            var livros = biblioteca.GetLivros();
            Assert.Contains(livroEsperado, livros);
        }
    }
}
