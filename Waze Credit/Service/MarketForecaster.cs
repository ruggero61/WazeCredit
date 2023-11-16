﻿namespace Waze_Credit.Service
{
    public class MarketForecaster : IMarketForecaster
    {
        public MarketResult GetMarketPrediction()
        {
            // Should be an API here, this is just a mock result...
            return new MarketResult() { Condition = Models.MarketCondition.StableUp };
        }
    }
}
