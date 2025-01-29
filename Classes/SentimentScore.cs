
using System.Collections.Generic;

namespace AIS.Service.Sentiment.Classes
{
    public class SentimentScore
    {
        public List<SentimentStrategyScore> ScoreDetails { get; set; }
        public double TotalScore { get; set; }
    }
}