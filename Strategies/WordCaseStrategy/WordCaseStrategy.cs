using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;

namespace AIS.Service.Sentiment.Strategies;

/// <summary>
/// Test de presencia de letras mayúsculas
/// </summary>
public class WordCaseStrategy : BaseSentimentStrategy
{
	public WordCaseStrategy()
	{
		Description = "WordCaseStrategy";
		ScoreCoefficient = 1;
	}

	public override async Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
	{
		var score = new SentimentStrategyScore() { Description = Description };

		foreach (var input in sentimentInput)
		{
			var text = input.Data.Replace(" ", ""); // texto sin espacios.
			int caseCount = 0;
			foreach (var c in text)
			{
				if (char.IsUpper(c))
					caseCount++;
			}
			if (caseCount > text.Length / 2) // Más de la mitad de los caracteres son mayúsculas.
				score.Score++; 
		}
		score.Score *= ScoreCoefficient;
		return await Task.FromResult(score);
	}
}
