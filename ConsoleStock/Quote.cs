using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStock
{
    class Quote
    {
        public string symbol { get; set; }
        public string timeUpdate { get; set; }
        public string dateTrade { get; set; }
        public double lastTrade { get; set; }
        public double previous { get; set; }
        public double change { get; set; }
        public double changeMonth { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
        public string timeLastTrade { get; set; }
        public string dateTradeObj { get; set; }
        public double quantity { get; set; }
        public double quantityLast { get; set; }
        public double quantityTrades { get; set; }
        public double volumeAmount { get; set; }
        public double volumeFinancier { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public string timeBid { get; set; }
        public string timeAsk { get; set; }
        public double volumeBid { get; set; }
        public double volumeAsk { get; set; }
        public double volumeBetterBid { get; set; }
        public double volumeBetterAsk { get; set; }
        public double lastTradeLastWeek { get; set; }
        public double lastTradeLastMonth { get; set; }
        public double lastTradeLastYear { get; set; }
        public string playerBid { get; set; }
        public double interest { get; set; }
        public string situation { get; set; }
        public double average { get; set; }
        public double execPrice { get; set; }
        public int tickSize { get; set; }
        public string timeLastTradeSting { get; set; }
        public string dateLastTradeString { get; set; }
        public int marketCode { get; set; }
        public double contractMultiplier { get; set; }
        public double volumeAverageLast20Days { get; set; }
        public double marketCap { get; set; }
        public double variation7Days { get; set; }
        public double variation1Month { get; set; }
        public double variation1Year { get; set; }
        public double variationVolumeInHour { get; set; }
        public double variationVolumeToHour { get; set; }
        public double variationVolumeInDay { get; set; }
        public double theoryPrice { get; set; }
        public double theoryQuantity { get; set; }
        public int loteDefault { get; set; }
        public double minIntervalIncrPrice { get; set; }
        public int quotationForm { get; set; }
        public double adjustmentDay { get; set; }
        public double adjustmentPreviousDay { get; set; }
        public string company { get; set; }
    }
}