
int[] QuantNum = new int[10];

Console.Write("Digite a quantidade de números que deseja inserir: ");
int quantidadeNumeros = int.Parse(Console.ReadLine()!);

for (int i = 0; i < quantidadeNumeros; i++)
{
    Console.Write($"Digite o número {i + 1}: ");
    QuantNum[i] = int.Parse(Console.ReadLine()!);
}

int somaPares = 0;
foreach (int numero in QuantNum)
{
    if (numero % 2 == 0)
    {
        somaPares += numero;
    }

}
if (somaPares > 0)
{
    Console.WriteLine($"A soma dos números pares é: {somaPares}");
}
else
{
    Console.WriteLine("Não foram inseridos números pares.");
}