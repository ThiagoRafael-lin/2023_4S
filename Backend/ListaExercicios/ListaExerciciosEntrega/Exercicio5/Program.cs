
Console.WriteLine("Digite um texto:");
string texto = Console.ReadLine();

Dictionary<char, int> contagemLetras = new Dictionary<char, int>();

foreach (char letra in texto.ToLower())
{
    if (Char.IsLetter(letra))
    {
        if (!contagemLetras.ContainsKey(letra))
        {
            contagemLetras[letra] = 0;
        }
        contagemLetras[letra]++;
    }
}

Console.WriteLine("\nContagem de letras:");
foreach (KeyValuePair<char, int> item in contagemLetras)
{
    Console.WriteLine($"'{item.Key}' aparece {item.Value} vez(es).");
}

