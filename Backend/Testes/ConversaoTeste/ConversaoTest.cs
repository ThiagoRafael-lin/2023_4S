using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conversao;


namespace ConversaoTest
{
    public class ConversaoTeste
    {
        [Fact]
        public void Test1()
        {
            var conversao = Converte.ConverterFarenheitParaCelsius(33.8);

            var expectedValue = 1;

            Assert.Equal(expectedValue, Math.Round(conversao));
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
}
