using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AirDrop.Models
{
   
    public class BitcoinData
    {
        public string id { get; set; }
        public string currency { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string logo_url { get; set; }
        public string status { get; set; }

        public string price;


        //MAX DECIMAL LIMIT SET TO 2
        public string Price {
            get {
                 double result = Double.Parse(price);
                return Math.Round(result, 2).ToString(); /*result.ToString("0.00");*/  }
            set {  }
        }
        public DateTime price_date { get; set; }
        public DateTime price_timestamp { get; set; }
        public string circulating_supply { get; set; }
        public string max_supply { get; set; }
        public string market_cap { get; set; }
        public string market_cap_dominance { get; set; }
        public string num_exchanges { get; set; }
        public string num_pairs { get; set; }
        public string num_pairs_unmapped { get; set; }
        public DateTime first_candle { get; set; }
        public DateTime first_trade { get; set; }
        public DateTime first_order_book { get; set; }
        public string rank { get; set; }
        public string rank_delta { get; set; }
        public string high { get; set; }
        public DateTime high_timestamp { get; set; }
        
        
     
    }
   

   
}
