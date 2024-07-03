using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Informe o número de dias do ano: ");
        if (!int.TryParse(Console.ReadLine(), out int numeroDeDias) || numeroDeDias <= 0)
        {
            Console.WriteLine("Número de dias inválido. Por favor, insira um número inteiro positivo.");
            return;
        }

        double[] faturamentoDiario = new double[numeroDeDias];

        for (int i = 0; i < numeroDeDias; i++)
        {
            Console.Write($"Informe o faturamento do dia {i + 1}: ");
            if (!double.TryParse(Console.ReadLine(), out faturamentoDiario[i]) || faturamentoDiario[i] < 0)
            {
                Console.WriteLine("Faturamento inválido. Por favor, insira um número não negativo.");
                i--; // Decrementar para repetir a entrada deste dia
            }
        }

        var (menor, maior, acimaMedia) = CalcularEstatisticasFaturamento(faturamentoDiario);

        Console.WriteLine($"Menor valor de faturamento: {menor}");
        Console.WriteLine($"Maior valor de faturamento: {maior}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {acimaMedia}");
    }

    static (double, double, int) CalcularEstatisticasFaturamento(double[] faturamentoAnual)
    {
        // Filtrar dias com faturamento
        var diasComFaturamento = faturamentoAnual.Where(valor => valor > 0).ToList();

        if (diasComFaturamento.Count == 0)
        {
            Console.WriteLine("Não houve faturamento em nenhum dos dias informados.");
            return (0, 0, 0);
        }

        // Encontrar o menor e o maior valor de faturamento
        double menorValor = diasComFaturamento.Min();
        double maiorValor = diasComFaturamento.Max();

        // Calcular a média anual
        double mediaAnual = diasComFaturamento.Average();

        // Contar dias com faturamento acima da média anual
        int diasAcimaDaMedia = diasComFaturamento.Count(valor => valor > mediaAnual);

        return (menorValor, maiorValor, diasAcimaDaMedia);
    }
}
