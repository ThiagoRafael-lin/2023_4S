using Conversao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ConversaoTeste
{
    public class TesteUnitario
    {
        [Fact]

        public void Teste1()
        {
            var conversao = Converte.ConverterFarenheitParaCelsius(33.8);

            var valorEsperado = 1;
        }

        [Fact]
        public void Test2()
        {
            var conversao = Converte.ConverterCelsiusParaFarenheit(1);

            var expectedValue = 33.8;

            Assert.Equal(expectedValue, conversao);
        }
    }

}
