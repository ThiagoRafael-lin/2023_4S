using ControleInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleInventarioTest
{
    public class TestInventario
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Test2(int value)
        {
            ControleDeInventario.AdicionarProduto("Bola");
            ControleDeInventario.AdicionarProduto("Bola");

            var qtdBola = ControleDeInventario.ObterQuantidade("Bola");

            Assert.Equal(value, qtdBola);
        }
    }

}

