System.Console.WriteLine("digite um numero");
int numPar = int.Parse(Console.ReadLine()!);

if (numPar % 2 == 0)
{
    System.Console.WriteLine($"seu número {numPar} é par");
} else {
    System.Console.WriteLine($"seu número é {numPar} é impar");
}

