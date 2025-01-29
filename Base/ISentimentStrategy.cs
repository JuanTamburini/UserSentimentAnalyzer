
using AIS.Service.Sentiment.Classes;

namespace AIS.Service.Sentiment.Base
{
	public interface ISentimentStrategy
    {
        /// <summary>
        /// Asigna un peso a la estrategia dentro del grupo de estrategias elegidas para la instancia y aplicación.
        /// Debe ser un número de 0 a byte.MaxValue.
        /// </summary>
        byte ScoreCoefficient { get; set; }

        string Description { get; set; }

        // TODO: La tabla de estrategias podría indicar si el proceso es async o no.
        Task<SentimentStrategyScore> AnalizeAsync(List<SentimentInput> sentimentInput);

        //SentimentStrategyScore Analize(List<SentimentInput> sentimentInput);
    }
}