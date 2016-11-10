﻿
using CurrencyTrader.Contracts;
using System.Collections.Generic;

namespace CurrencyTrader
{
    public class TradeProcessor
    {
        IEnumerable<string> lines;
        IEnumerable<TradeRecord> trades;

        public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
        {
            this.tradeDataProvider = tradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }

        public void ProcessTrades()
        {
            lines = tradeDataProvider.GetTradeData();
            trades = tradeParser.Parse(lines);
            tradeStorage.Persist(trades);
        }

        public IEnumerable<string> ReadTrades()
        {
            lines = tradeDataProvider.GetTradeData();
            return lines;
        }
        public IEnumerable<TradeRecord> ParseTrades()
        {
            trades = tradeParser.Parse(lines);
            return trades;
        }
        public void StoreTrades()
        {
            tradeStorage.Persist(trades);
        }

        private readonly ITradeDataProvider tradeDataProvider;
        private readonly ITradeParser tradeParser;
        private readonly ITradeStorage tradeStorage;
    }
}
