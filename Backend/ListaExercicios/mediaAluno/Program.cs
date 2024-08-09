Console.WriteLine("Digete as notas");

int QuantidadeDeNotas = int.Parse(Console.ReadLine()!);

int[] notas = new int[QuantidadeDeNotas];

for (int i = 0; i < QuantidadeDeNotas; i++)
{
    System.Console.WriteLine($"Digite a nota {i + 1}");
    notas[i] = int.Parse(Console.ReadLine()!);
}

Console.WriteLine("\nAs notas digitadas são:");
foreach (int nota in notas)
{
     
    if (nota > 7)
    {
        System.Console.WriteLine($"{nota} você foi aprovado!");
    } else {
        System.Console.WriteLine($"{nota} você foi reprovado!");
    }
}






/* 
Exercício:

5) Você vai criar um programa que armazena as notas de vários alunos em diferentes disciplinas. O programa deve calcular a média de cada aluno e determinar quais alunos têm médias acima de 7.0 (aprovados) e quais têm médias abaixo de 7.0 (reprovados). O programa deve usar foreach para iterar sobre as coleções de alunos e suas notas.

Especificações:

- Armazene as notas de 3 disciplinas para cada aluno.
- Calcule a média de cada aluno.
- Exiba a média e o status (aprovado/reprovado) de cada aluno.
- Use foreach para iterar sobre os alunos e as disciplinas.
*/