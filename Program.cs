// See https://aka.ms/new-console-template for more information
using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using AIS.Service.Sentiment.Strategies;
using System.Text;

// Necesitamos este encoding para que detecte bien los emojis.
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("User Sentiment Analyzer");

var estrategias = EstrategiasDisponibles();
string strEstrategias = "";
foreach (var estrategia in estrategias)
	strEstrategias += estrategia.Description + ", ";
Console.WriteLine("Estrategias activas: " + strEstrategias);
while (true)
{
	Console.WriteLine();
	Console.WriteLine("Ingrese 1 para ingresar textos manualmente");
	Console.WriteLine("Ingrese 2 para ejecutar una prueba preestablecida");
	string input = Console.ReadLine();
	if (int.TryParse(input, out var opcionIngresada))
	{
		// Modificar si se agregan opciones
		if (opcionIngresada > 2 || opcionIngresada < 1)
		{
			Console.WriteLine("Opción desconocida");
			continue;
		}
		if (opcionIngresada == 1)
			while (true)
				RunManualInputMethod();
		else if (opcionIngresada == 2)
			RunPrestablishedInputMethod();
	}
	else
		Console.WriteLine($"\nOpción inexistente (presione cualquier tecla para continuar)");
}

List<BaseSentimentStrategy> EstrategiasDisponibles() => new() { new UnhappyCharStrategy() };

async Task<SentimentScore> Analize(List<SentimentInput> inputs)
{
	var sentimentScore = new SentimentScore();
	foreach (var estrategia in estrategias)
	{
		var score = await estrategia.AnalizeAsync(inputs);
		sentimentScore.ScoreDetails.Add(score);
	}
	return sentimentScore;
}

void LogScore(SentimentScore sentimentScore)
{
	Console.WriteLine();
	Console.WriteLine("Score total: " + sentimentScore.TotalScore);
	foreach (var score in sentimentScore.ScoreDetails)
	{
		Console.WriteLine("Score estrategia " + score.Description + ": " + score.Score);
	}
}

async void RunManualInputMethod() 
{
	Console.WriteLine();
	Console.WriteLine("Ingrese el texto a analizar:");
	string text = Console.ReadLine();

	var score = await Analize(new() { new SentimentInput { Data = text } });
	LogScore(score);
}

async void RunPrestablishedInputMethod()
{
	Console.WriteLine("Sin implementar");
}

