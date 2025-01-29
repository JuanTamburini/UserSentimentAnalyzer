using AIS.Service.Sentiment.Base;
using AIS.Service.Sentiment.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIS.Service.Sentiment.Strategies
{
    internal class LLMStrategy : BaseSentimentStrategy
    {
        #region Constants

        public byte ScoreCoefficient { get; set; } = byte.MaxValue;
        public string Description { get; set; }

        public Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}