using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.Service.Sentiment.Strategies
{
    /// <summary>
    /// Test de caracteres o conjunto de caracteres o emojis que expresan enojo
    /// </summary>
    public class UnhappyCharStrategy : BaseSentimentStrategy
    {
        #region Constants

        public byte ScoreCoefficient { get; set; } = byte.MaxValue;
        public string Description { get; set; }

        #endregion

        public async Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
        {
            var sentimentScorePartial = new SentimentStrategyScore();

            // TODO... recorrer y ejecutar cada sentimentStragegy y botener su resultado...

            // TODO: ponderar todos los resultados y devovlerlos en sentimenScore...

            return await Task.FromResult(sentimentScorePartial);
        }
    }
}