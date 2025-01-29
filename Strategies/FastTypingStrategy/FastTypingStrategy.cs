using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.Service.Sentiment.Strategies
{
    /// <summary>
    /// Test de muchos mensajes al mismo tiempo
    /// </summary>
    public class FastTypingStrategy : BaseSentimentStrategy
    {
        public new byte ScoreCoefficient { get; set; } = 50;

        public override Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
        {
            throw new System.NotImplementedException();
        }
    }
}