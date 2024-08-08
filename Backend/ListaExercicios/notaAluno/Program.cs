using System;
using System.Linq;

namespace CalculadoraMediaNotas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantas notas você deseja inserir? ");
            int quantidadeDeNotas = int.Parse(Console.ReadLine());

            double[] notas = new double[quantidadeDeNotas];
            double somaDasNotas = 0;

            for (int i = 0; i < quantidadeDeNotas; i++)
            {
                Console.Write($"Digite a nota {i + 1}: ");
                notas[i] = double.Parse(Console.ReadLine());
                somaDasNotas += notas[i];
            }

            double media = somaDasNotas / quantidadeDeNotas;

            if (media >= 7)
            {
                Console.WriteLine($"A média do aluno é: {media}. Não há necessidade de recuperação.");
            }
            else
            {
                Console.WriteLine($"A média do aluno é: {media}. Há necessidade de recuperação.");
            }
        }
    }
}
