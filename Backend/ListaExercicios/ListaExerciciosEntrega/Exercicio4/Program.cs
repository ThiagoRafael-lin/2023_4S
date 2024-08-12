

Console.WriteLine("Digite um número para ver sua tabuada:");
int numero = Convert.ToInt32(Console.ReadLine());

GerarTabuada(numero);

static void GerarTabuada(int numero)
{
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine($"{numero} x {i} = {numero * i}");
    }
}
