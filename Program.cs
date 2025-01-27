using AppRisk.Interface;
using AppRisk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRisk
{

    class Program
	{
		static void Main()
		{
			// Lê a data de referência
			Console.WriteLine("Informe data de referência (MM/dd/yyyy):");
			DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);

			// Lê o número de operações
			Console.WriteLine("Enter the number of trades:");
			int n = int.Parse(Console.ReadLine());

			// Criação do motor de classificação
			RiskClassificacao engine = new RiskClassificacao(referenceDate);

			List<ITrade> trades = new List<ITrade>();

			// Leitura das operações
			for (int i = 0; i < n; i++)
			{
				Console.WriteLine($"Entre trade {i + 1} detalhes (Value ClientSector ProximoPagamento):");
				string[] input = Console.ReadLine().Split(' ');

				if (double.TryParse(input[0], out double value))
				{
					
					string clientSector = input[1];
					DateTime nextPaymentDate = DateTime.ParseExact(input[2], "MM/dd/yyyy", null);

					trades.Add(new Trade(value, clientSector, nextPaymentDate));
				}
				else
					Console.WriteLine("Valor errado");
			}

			// Classificação das operações e exibição dos resultados
			foreach (var trade in trades)
			{
				var category = engine.Classificar(trade);
				Console.WriteLine($"Trade Value: {trade.Value}, Sector: {trade.ClientSector}, Next Payment: {trade.NextPaymentDate.ToShortDateString()}, Category: {category}");
			}
		}
	}

}
