using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validacao
{
    public class EmailValidator
    {
        public static boolean validarEmail(String email)
        {
            // Simplificando a validação apenas para verificar a presença de "@" e "."
            return email != null && email.contains("@") && email.contains(".");
        }
    }
}
