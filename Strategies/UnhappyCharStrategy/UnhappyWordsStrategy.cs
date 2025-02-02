using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserSentiment.Data;

namespace AIS.Service.Sentiment.Strategies
{
    public class UnhappyWordsStrategy : BaseSentimentStrategy
    {
        #region Constants

        private readonly List<UnhappyWord> unhappyWords;

		#endregion

		#region Constructor

		public UnhappyWordsStrategy()
		{
			Description = "UnhappyWordsStrategy";
			ScoreCoefficient = 1;
			unhappyWords = UnhappyWord.GetUnhappyWordsMock();
		}

		#endregion

		public async override Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
        {
            var score = new SentimentStrategyScore();
			foreach(var input in sentimentInput)
			{
				var inputText = input.Data;
				// Dividiendo el input por palabras evita que podamos analizar frases que representan insultos.
				var inputWords = inputText.Split(' ');

				// Recorremos cada palabra del input analizado
				foreach (var word in inputWords)
				{
					foreach (var unhappyWord in unhappyWords)
					{
						int levDistance = Framework.StringService.ComputeLevenshteinDistance(word, unhappyWord.Word);
						
						if (word.Equals(unhappyWord.Word, StringComparison.OrdinalIgnoreCase) || levDistance <= 2) // Se puede ajustar la distancia..
						{
							score.Score += unhappyWord.Weight;
						}
					}
				}
			}

			// El coeficiente indicaria un peso extra a las coincidencias de esta estrategia.
			score.Score *= ScoreCoefficient;
			return await Task.FromResult(score);
        }
    }
}