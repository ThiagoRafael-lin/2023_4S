Random rand = new();

int numAleatorio = rand.Next(0, 100);
int numeEscolhido = 0;
int tentativas = 0;

Console.WriteLine($"O numero aleatorio é: {numAleatorio}");

do
{
    Console.WriteLine("Escolha um numero de 0 a 10");
    numeEscolhido = int.Parse(Console.ReadLine()!);

    tentativas++;
    while (numeEscolhido != numAleatorio)
    {
        tentativas++;
        if (numeEscolhido < numAleatorio)
        {
            Console.WriteLine("tenta um número maior");
        }
        else if (numeEscolhido > numAleatorio)
        {
            Console.WriteLine("tenta um número menor");
        }
        numeEscolhido = int.Parse(Console.ReadLine()!);

    }
} while (numeEscolhido != numAleatorio);

Console.WriteLine($"Parabéns você acertou, você tentou: {tentativas} vezes");
