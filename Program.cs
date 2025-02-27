using System.ComponentModel.Design;
using System.Threading.Channels;

Menu();




























static void Menu()
{
    Console.WriteLine("Bem vindo ao Converter!");
    Console.WriteLine("O que gostaria de fazer?");
    Console.WriteLine("1 - Decimal para Binario;");
    Console.WriteLine("2 - Binario para Decimal;");
    Console.WriteLine("3 - Sair.");

    int x = int.Parse(Console.ReadLine());

    switch (x)
    {
        case 1:
            ConvertDToB();
            break;

        case 2:
            ConvertBToD();
                break;


        case 3:
            break;

        default:
            Console.WriteLine("Por favor insira uma opçãp Válida.");
            Menu();
            break;


    }
}



static void ConvertDToB()
{
    Console.Write("Introduza um número decimal para converter para binário: ");
    if (!int.TryParse(Console.ReadLine(), out int x))
    {
        Console.WriteLine("Número inválido!");
        Console.WriteLine();
        Console.WriteLine("Por favor introduz um decimal válido!");
        ConvertDToB();
        

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


static void ConvertBToD()
{
    Console.WriteLine("Introduz o Binario (0 ou 1) que pretende converter para Decimal, quando terminar carregue no enter!");

    List<int> bn = new List<int>();


    BNAdd(bn);
    bn.Reverse();
    BNT(bn);




    

    if (bn.Count > 0)
    {
        for (int i = bn.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("indice " + i + ": " + bn[i]);
        }
    }



    static void BNAdd(List<int> bn)
    {
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        foreach (char c in input)
        {
            if (c == '0' || c == '1')
            {
                bn.Add(c - '0');
            }
            else
            {
                Console.WriteLine("Carácter inválido! Apenas 0 ou 1 são permitidos. Tente novamente.");
                BNAdd(bn);
                return;
            }
        }


       


    }

    

    static void BNT(List<int> bn)
    {
        int dc = 0;

        for (int j = bn.Count - 1; j >= 0; j--)
        {
            int rsl = (int)Math.Pow(2, j) * bn[j];
            dc = dc + rsl;
        }

        Console.WriteLine(dc);
    }

    Menu();

}
