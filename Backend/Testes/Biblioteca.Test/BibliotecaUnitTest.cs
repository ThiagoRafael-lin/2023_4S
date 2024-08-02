using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Biblioteca;



namespace Biblioteca.Test
{
   public class BibliotecaUnitTest
    {
        [Fact]
        public void AdicionarLivro()
        {
            string[] resultado = Biblioteca.Livro.AdicionarLivro("Dom Casmurro");

            string[] expectedValue = resultado;

            Assert.Equal(expectedValue, resultado);
        }
    }
}
