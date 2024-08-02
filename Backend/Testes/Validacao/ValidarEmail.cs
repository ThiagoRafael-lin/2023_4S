using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Validacao
{
    public static class EmailValidator
    {
        public static bool ValidaEmail(string email)
        {
            return email.Contains("@") && email.Contains(".") && email.Split("@")[0].Length > 5;    
        }
    }
}
