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
		ScoreCoefficient = byte.MaxValue;
	}

	public int Score;

	public override async Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
	{
		var score = new SentimentStrategyScore();

		//foreach (var input in sentimentInput)
		//{
		//	score.Score += CheckForWords(input.Data, UnhappyWords);
		//}

		return score;
	}
}
