
using AIS.Service.Sentiment.Classes;

namespace AIS.Service.Sentiment.Base
{
	public class BaseSentimentStrategy : ISentimentStrategy
    {
        public byte ScoreCoefficient { get; set; }

        public string Description { get; set; }

        public virtual Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput)
        {
            throw new NotImplementedException();
        }
    }
}