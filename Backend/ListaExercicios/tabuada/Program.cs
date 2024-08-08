namespace tabuada
{
    class Programa
    {
        static void Main(string[] args)
        {
            //pede para escrever um numero
            Console.WriteLine("Insira um numero de 1 a 10");

            //captura o numero escrito no console, e armazena na variavel int 
            int numero = int.Parse(Console.ReadLine()!);

            //estrutura de repetição, declara a variavel, da a condição para a variavel junto do seu limite, e depois incrementa ou decrementa
            for (int i = 1; i <= 10; i++)
            {
                //imprime a resposta do for no console, numero que é a variavel criada, vezes a variavel do for
                Console.WriteLine($"{numero} x {i} = {numero * i}");
            }
        }
    }
}
