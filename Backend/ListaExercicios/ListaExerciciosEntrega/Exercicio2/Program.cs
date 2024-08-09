
System.Console.WriteLine("Insira 5 nomes");

string[] nome = new string[5];

for (int i = 0; i < 5 ; i++)
{
    nome[i] = Console.ReadLine(); 
}

Array.Sort(nome);

foreach (var item in nome)
{
    
System.Console.WriteLine(item);
}
