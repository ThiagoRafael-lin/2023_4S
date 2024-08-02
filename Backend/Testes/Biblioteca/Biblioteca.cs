using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Livro
    {
        public static List<string>? ListaLivros { get; set; } = new List<string>();

        public static string[] AdicionarLivro(string novoLivro)
        {
            ListaLivros!.Add(novoLivro);
            return ListaLivros!.ToArray();
        }
    }
}

