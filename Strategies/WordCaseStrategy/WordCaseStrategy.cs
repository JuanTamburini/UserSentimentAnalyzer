using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using UserSentiment.Data;

namespace AIS.Service.Sentiment.Strategies;

/// <summary>
/// Test de presencia de letras mayúsculas
/// </summary>
public class WordCaseStrategy : BaseSentimentStrategy
{
	private readonly List<string> UnhappyWords = UnhappyWordsMock.UnhappyWords;
	public WordCaseStrategy()
	{
		Description = "WordCaseStrategy";
		ScoreCoefficient = byte.MaxValue;
	}

	public int Score;

	public override async Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
	{
		var score = new SentimentStrategyScore();

		foreach (var input in sentimentInput)
		{
			score.Score += CheckForWords(input.Data, UnhappyWords);
		}

		return score;
	}

	private static double CheckForWords(string input, List<string> words)
	{
		int score = 0;
		var inputWords = input.Split(' ');

		foreach (var inputWord in inputWords)
		{
			foreach (var word in words)
			{
				int distance = LevenshteinDistance(inputWord, word);
				if (inputWord.Equals(word, StringComparison.OrdinalIgnoreCase) || distance <= 2) // Adjust threshold as needed
				{
					// Increment score based on how close the match is
					score += 1 / (distance + 1); // Closer matches contribute more to the score
				}
			}
		}
		return score;
	}

	static int LevenshteinDistance(string source, string target)
	{
		if (string.IsNullOrEmpty(source)) return target.Length;
		if (string.IsNullOrEmpty(target)) return source.Length;

		var d = new int[source.Length + 1, target.Length + 1];

		for (int i = 0; i <= source.Length; d[i, 0] = i++) { }
		for (int j = 0; j <= target.Length; d[0, j] = j++) { }

		for (int i = 1; i <= source.Length; i++)
		{
			for (int j = 1; j <= target.Length; j++)
			{
				int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
				d[i, j] = Math.Min(
					Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
					d[i - 1, j - 1] + cost);
			}
		}

		return d[source.Length, target.Length];
	}
}
