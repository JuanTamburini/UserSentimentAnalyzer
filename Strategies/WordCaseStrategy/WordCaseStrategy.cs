using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.Service.Sentiment.Strategies
{
    /// <summary>
    /// Test de presencia de letras mayúsculas
    /// </summary>
    public class WordCaseStrategy : BaseSentimentStrategy
    {
        public byte ScoreCoefficient { get; set; } = 125;

        public string Description { get; set; }

        public Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
        {
            throw new System.NotImplementedException();
        }
    }
}