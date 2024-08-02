using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validacao;
using System;


namespace EmailValidationTests
{
   public class ValidacaoEmailTest
    {
        [Fact]

        public void ValidacaoTest()
        {
            bool valido = EmailValidator.ValidaEmail("tinas@gmail.com");

            Assert.True(valido);
        }
    }


}
