using CurrencyTrader;
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {

        private readonly String url;
        ITradeDataProvider urlProvider;

        public AdjustTradeDataProvider(string url) {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradeData = urlProvider.GetTradeData();
            string tempLine;
            var trades = new List<String>();

            //changes GBP to EUR
            foreach (string line in tradeData)
            {
                tempLine = line.Replace("GBP", "EUR");
                trades.Add(tempLine);
            }
                return trades;
        }
    }
}
