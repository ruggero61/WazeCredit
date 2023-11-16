namespace Waze_Credit.Service
{
    public class MarketForecasterV2 : IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // Should be an API here, this is just a mock result...
            return new MarketResult() { Condition = Models.MarketCondition.StableDown };
        }
    }
}
