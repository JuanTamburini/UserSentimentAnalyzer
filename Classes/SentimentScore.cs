
using System.Collections.Generic;

namespace AIS.Service.Sentiment.Classes
{
    public class SentimentScore
    {
        public List<SentimentStrategyScore> ScoreDetails { get; set; } = new();
        public double TotalScore 
        {
            get
            {
                if (ScoreDetails is null || ScoreDetails.Count == 0)
                    return 0;
                else
                {
                    double scoreCount = 0;
					foreach (var score in ScoreDetails)
					{
						scoreCount += score.Score;
					}
					return scoreCount;
                }
            }
        }
    }
}