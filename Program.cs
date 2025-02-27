using System.ComponentModel.Design;


Menu();


























static void Menu()
{
    Console.WriteLine("Bem vindo ao Converter!");
    Console.WriteLine("O que gostaria de fazer?");
    Console.WriteLine("1 - Decimal to Binary;");
    Console.WriteLine("2 - Sair.");

    int x = int.Parse(Console.ReadLine());

    switch (x)
    {
        case 1:
            Convert();
            break;

        case 2:
            break;

        default:
            Console.WriteLine("Por favor insira uma opçãp Válida.");
            Menu();
            break;


    }
}



static void Convert()
{
    Console.Write("Introduza um número decimal para converter para binário: ");
    if (!int.TryParse(Console.ReadLine(), out int x))
    {
        Console.WriteLine("Número inválido!");
        Console.WriteLine();
        Console.WriteLine("Por favor introduz um decimal válido!");
        Convert();
        

    }


        List<int> b = new List<int>();
    int qo = x;

    while (qo > 0)
    {
        b.Add(qo % 2);
        qo /= 2;
    }

    if (b.Count == 0) b.Add(0); // Caso seja 0, garante a saída correta


    for (int i = b.Count - 1; i >= 0; i--)
    {
        Console.WriteLine("indice " + i + ": " + b[i]);
    }

    Console.WriteLine();

    b.Reverse();
    Console.Write("Número em binário: ");
    foreach (var bit in b)
    {
        Console.Write(bit);
    }
    Console.WriteLine();
    Menu();
}