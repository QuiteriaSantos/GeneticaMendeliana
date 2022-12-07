string Pessoa1, Pessoa2, Pessoa11, Pessoa22;
string fusao14, fusao19, fusao12, fusao24;
string modificacaoAA, modificacaoAa, modificacaoaa;

double gratificacaoAA, gratificacaoAa, gratificacaoaa;

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("    Genética Mendeliana    \n");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkGreen;

Console.Write("Gene do Pessoa 1 (AA, Aa ou aa): ");
string individuo1 = NormalizaGene(Console.ReadLine()!.Trim().Substring(0, 2));
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write("Genes do Pessoa 2 (AA, Aa ou aa): ");
string individuo2 = NormalizaGene(Console.ReadLine()!.Trim().Substring(0, 2));
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkGreen;

Console.Write("Tipo de dominância (C/I): ");
string dominancia = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();
Console.ResetColor();

if (dominancia != "C" && dominancia != "I")
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Tipo de dominância inválido.");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.DarkMagenta;

Pessoa1 = individuo1.Substring(0, 1);
Pessoa2 = individuo1.Substring(1, 1);
Pessoa11 = individuo2.Substring(0, 1);
Pessoa22 = individuo2.Substring(1, 1);


fusao14 = NormalizaGene($"{Pessoa1}{Pessoa1}");
fusao19 = NormalizaGene($"{Pessoa1}{Pessoa2}");
fusao12 = NormalizaGene($"{Pessoa22}{Pessoa11}");
fusao24 = NormalizaGene($"{Pessoa22}{Pessoa22}");


Console.WriteLine();
Console.WriteLine($"  | {Pessoa1}  |  {Pessoa2}");
Console.WriteLine($"-----------");
Console.WriteLine($"{Pessoa11} | {fusao12} | {fusao19}");
Console.WriteLine($"-----------");
Console.WriteLine($"{Pessoa22} | {fusao14} | {fusao24}");


gratificacaoAA = 100 * (
    (fusao14 == "AA" ? 1 : 0) +
    (fusao12 == "AA" ? 1 : 0) +
    (fusao19 == "AA" ? 1 : 0) +
    (fusao24 == "AA" ? 1 : 0)
) / 4;

gratificacaoAa = 100 * (
    (fusao14 == "Aa" ? 1 : 0) +
    (fusao12 == "Aa" ? 1 : 0) +
    (fusao19 == "Aa" ? 1 : 0) +
    (fusao24 == "Aa" ? 1 : 0)
) / 4;

gratificacaoaa = 100 * (
    (fusao14 == "aa" ? 1 : 0) +
    (fusao12 == "aa" ? 1 : 0) +
    (fusao19 == "aa" ? 1 : 0) +
    (fusao24 == "aa" ? 1 : 0)
) / 4;
Console.ResetColor();


if (dominancia == "C")
{
    modificacaoAA = "Não apresenta a características recessiva";
    modificacaoAa = "Não apresenta a características recessiva";
    modificacaoaa = "Apresenta a características recessiva";
}
else
{
    modificacaoAA = "Apresenta a características de `A`";
    modificacaoAa = "Apresenta características distinta de `A` e de `a`";
    modificacaoaa = "Apresenta a características de `a`";
}

Console.ForegroundColor = ConsoleColor.DarkRed;


Console.WriteLine();
Console.WriteLine($"AA: {gratificacaoAA,3}% - {modificacaoAA}");
Console.WriteLine($"Aa: {gratificacaoAa,3}% - {modificacaoAa}");
Console.WriteLine($"aa: {gratificacaoaa,3}% - {modificacaoaa}");
Console.ResetColor();

 
string NormalizaGene(string Gene)

{
    string Gene1 = Gene.Substring(0, 1);
    string Gene2 = Gene.Substring(1, 1);

    if (Gene1 == "a")
    {
        string auxiliar = Gene1;
        Gene1 = Gene2;
        Gene2 = auxiliar;
    }

    return $"{Gene1}{Gene2}";
}

