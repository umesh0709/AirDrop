using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AirDrop.Models
{

    public class Bitcoin
    {
        public int usd;
    }

   


    public class Root
    {
        public List<Coin> coins { get; set; }
        public List<object> exchanges { get; set; }
    }

    public class Coin
    {
        public Item item { get; set; }
    }
    public class Item
    {
        public string id { get; set; }
        public int coin_id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public string symbol { get; set; }
        public int market_cap_rank { get; set; }
        public string thumb { get; set; }
        public string small { get; set; }
        public string large { get; set; }
        public string slug { get; set; }
        public double price_btc { get; set; }
        public int score { get; set; }
    }


}
