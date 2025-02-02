using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserSentiment.Data;

namespace AIS.Service.Sentiment.Strategies
{
	/// <summary>
	/// Test de caracteres o conjunto de caracteres o emojis que expresan enojo
	/// </summary>
	public class UnhappyCharStrategy : BaseSentimentStrategy
	{
		private readonly List<UnhappyChar> unhappyChars;
		public UnhappyCharStrategy()
		{
			Description = "UnhappyCharStrategy";
			ScoreCoefficient = 1;
			unhappyChars = UnhappyChar.GetUnhappyCharsMock();
		}

		// TODO: Copiando y pegando emojis no trae unicode si no "???????". Ver con Seba
		public override async Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInputs)
		{
			var sentimentScorePartial = new SentimentStrategyScore() { Description = Description };

			// Recorremos cada input
			foreach (var input in sentimentInputs)
			{
				var inputText = input.Data;
				var coincidences = unhappyChars.FindAll(x => inputText.Contains(x.SpecialChars));
				foreach(var coincidence in coincidences)
				{
					sentimentScorePartial.Score += coincidence.Weight;
				}
			}

			// El coeficiente indicaria un peso extra a las coincidencias de esta estrategia.
			sentimentScorePartial.Score *= ScoreCoefficient;

			return await Task.FromResult(sentimentScorePartial);
		}
	}
}