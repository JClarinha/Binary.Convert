using System.Collections;
using System.ComponentModel.Design;
using System.Threading.Channels;
using System.Linq;
using System;

Menu();


static void Menu()
{
    Console.WriteLine("Bem vindo ao Converter!");
    Console.WriteLine("O que gostaria de fazer?");
    Console.WriteLine("1 - Converter Decimal para Binario;");
    Console.WriteLine("2 - Converter Binario para Decimal;");
    Console.WriteLine("3 - Converter Decimal para Hexadecimal;");
    Console.WriteLine("4 - Converter Hexadecimal para Decimal;");
    Console.WriteLine("5 - Sair.");

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
            ConvertDToHx();
            break;


        case 4:
            ConvertHxToD();
            break;

        default:
            Console.WriteLine("Por favor insira uma opçãp Válida.");
            Menu();
            break;


    }
}



static void ConvertDToB() // converte de decimal para binario com validação de input
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


static void ConvertDToHx()
{

    Console.Write("Introduza um número decimal para converter para hexadecimal: ");
    if (!int.TryParse(Console.ReadLine(), out int x))
    {
        Console.WriteLine("Número inválido!");
        Console.WriteLine();
        Console.WriteLine("Por favor introduz um decimal válido!");
        ConvertDToHx();


    }

    int rst;
    int qo;

    
    ArrayList hx = new ArrayList();

    string hexChar = "0123456789ABCDEF";

    while (x > 0 )
    {
        rst = x % 16;
        char Hxd = hexChar[rst];
        hx.Add(Hxd);
        x /= 16;        
    }

   
    

    for (int i = hx.Count - 1; i >= 0; i--)
    {
        Console.WriteLine("indice " + i + ": " + hx[i]);
    }

    hx.Reverse();
    Console.Write("Número em Hexadecimal: ");
    foreach (var bit in hx)
    {
        Console.Write(bit);
    }
    Console.WriteLine();

    Menu();


}

static void ConvertHxToD()
{
    string hexChar = "0123456789ABCDEF";

    ArrayList ToConvert = new ArrayList();

    Console.WriteLine("Introduza um Hexadecimal para converter para Decimal: ");
    string inp = Console.ReadLine().ToUpper();

    Console.WriteLine();

    Console.WriteLine(inp);

    bool check = inp.All(c => hexChar.Contains(c));

    if (!check)
    {
        Console.WriteLine("Por favor introduz um Hexadecimal válido!");
        ConvertHxToD();
    }

    else
    {
        for (int i = 0; i < inp.Length; i++)
        {
            ToConvert.Add(inp[i]);
        } // Adiciona os caracteres que o utilizador colocou na ArraList

        for (int q = 0; q < ToConvert.Count; q++)
        {
            if (ToConvert[q] is char c && c >= 'A' && c <= 'F')
            {
                int valor = c - 'A' + 10;
                ToConvert[q] = valor;
            }
        }


        int rst = 0;
        int exp = 0;

        for (int j = ToConvert.Count-1; j >= 0; j--)
        {

            int rsl = (int)Math.Pow(16, exp) * (int)ToConvert[j];
            rst = rst + rsl;
            exp++;
        }
        Console.WriteLine();
        Console.WriteLine(inp + " Em decimal é: " + rst);
    }
    Console.WriteLine();
    Console.WriteLine();

    Menu();

}
