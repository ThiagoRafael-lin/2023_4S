using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculos.Test
{
    public class CalculoUnitTest
    {
        //princípio AAA : Act, Arrange e Assert
        //princípio AAA : Agir, Organizare e Provar

        [Fact]
        public void SomarDoisNumeros()
        {
            //Organizar (Arrange)
            var n1 = 3.3;
            var n2 = 2.2;
            var valorEsperado = 5.5;

            //Agir (Act)
            var soma = Calculo.Somar(n1, n2);

            //Provar (Assert)
            Assert.Equal(valorEsperado, soma);

        }

        [Fact]
        public void SubtrairDoisNumero()
        {
            var n1 = 5; 
            var n2 = 4;
            var valorEsperado = 1;

            var soma = Calculo.Subtrair(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact] 
        public void DividirDoisNumero()
        {
            var n1 = 4;
            var n2 = 2;
            var valorEsperado = 2;

            var soma = Calculo.Dividir(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

        [Fact]
        public void MultiplicarDoisNumero()
        {
            var n1 = 2;
            var n2 = 2;
            var valorEsperado = 4;

            var soma = Calculo.Multiplicar(n1, n2);

            Assert.Equal(valorEsperado, soma);
        }

    }
}
