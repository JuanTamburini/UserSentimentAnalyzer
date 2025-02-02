// See https://aka.ms/new-console-template for more information
using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Strategies;

Console.WriteLine("User Sentiment Analyzer");

List<BaseSentimentStrategy> EstrategiasDisponibles() => new() { new WordCaseStrategy() };

var estrategias = EstrategiasDisponibles();
Console.WriteLine("Estrategias activas:");
foreach (var estrategia in estrategias)
	Console.WriteLine(estrategia.Description);
while (true)
{

	Console.WriteLine("Ingrese 1 para ingresar textos manualmente");
	Console.WriteLine("Ingrese 2 para ejecutar una prueba preestablecida");
	string input = Console.ReadLine();
	if (int.TryParse(input, out var opcionIngresada))
	{
		if (opcionIngresada > 2 || opcionIngresada < 1)
		{
			Console.WriteLine("Opción desconocida");
			continue;
		}


	}
	else
		Console.WriteLine($"\nOpción inexistente (presione cualquier tecla para continuar)");
	Console.ReadKey();
}
