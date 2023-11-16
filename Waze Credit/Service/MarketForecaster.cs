namespace Waze_Credit.Service
{
    public class MarketForecaster
    {
        public MarketResult GetMarketPrediction()
        { 
            return new MarketResult() { Condition=Models.MarketCondition.StableUp};
        }
    }
}
