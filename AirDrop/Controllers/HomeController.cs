using AirDrop.Data;
using AirDrop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace AirDrop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        MultipleTables list = new MultipleTables();

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void main()
        {
           // Console.WriteLine(TrendingCoins());
          //  Console.Read();
        }
        public IActionResult Index()
        {


            /*list.CryptoInfo = _db.CryptoInfo.Take(5).ToList();
            list.Tweets = _db.Tweets.ToList();*/
            // IEnumerable<CryptoInfo> infoList = _db.CryptoInfo
            // ViewBag.trendingCoins = TrendingCoins();
            ViewBag.dailyChange = DailyChange();
            ViewBag.cryptoCurrencyData = GetCurrencyData();
            ViewBag.currentAirdropsData = GetCurrentAirdropsData();
            ViewBag.tweets = Tweets();
            return View();
        }

        [HttpGet]
        public List<CurrentAirdropsData> GetCurrentAirdropsData()
        {
          
            List<CurrentAirdropsData> cryptoInfo = new List<CurrentAirdropsData>();
            string mainConn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(mainConn);
            string sqlQuerryCryptoInfo = "SELECT * FROM CryptoInfo";
            sqlConn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlQuerryCryptoInfo, sqlConn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlComm);
            DataTable dataTable = new DataTable();
            sdr.Fill(dataTable);
            foreach(DataRow dr in dataTable.Rows) {
                CurrentAirdropsData cr = new CurrentAirdropsData();
                cr.Name = dr["name"].ToString();
                cr.Info = dr["info"].ToString();
               if(!Convert.IsDBNull(dr["dropimage"])) {
                    cr.DropImage = (byte[])dr["dropimage"];
                }
               
                cr.ParticipateLink = dr["participatelink"].ToString();
                cryptoInfo.Add(cr);
            }
            sqlConn.Close();
            return cryptoInfo;
        }

        public List<CryptoCurrencyData> GetCurrencyData()
        {
            List<CryptoCurrencyData> currency = new List<CryptoCurrencyData>();
            
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://api.nomics.com/v1/");
                var responseTask = client.GetAsync("currencies/ticker?key=60554f1aac4ec6ecf9d934a78719834f353163ae&ids=BTC,ETH,BNB");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {
                    Task<string> json = result.Content.ReadAsStringAsync();
                    List<CryptoCurrencyData> currencyData = JsonConvert.DeserializeObject<List<CryptoCurrencyData>>(json.Result);
                    return currencyData;
                }


            }
                return null;
        }

        public List<_1d> DailyChange()
        {
            List<_1d> dailyChange = new List<_1d>();

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://api.nomics.com/v1/");
                var responseTask = client.GetAsync("currencies/ticker?key=60554f1aac4ec6ecf9d934a78719834f353163ae&ids=BTC");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {
                    Task<string> json = result.Content.ReadAsStringAsync();
                    dailyChange = JsonConvert.DeserializeObject<List<_1d>>(json.Result);

                    return dailyChange;
                }
            }
            return null;


        }

        // NOT WORKING 

        public  IActionResult TrendingCoins()
        {
            var client = new WebClient();
            string json = client.DownloadString(@"https://api.coingecko.com/api/v3/search/trending");
            Item items = JsonConvert.DeserializeObject<Item>(json);
            return View(items);
          /*  var model = ConvertJsonToString();
            return View(model);*/
        }

        [HttpGet]
       /* private Coins ConvertJsonToString()
        {
          // IEnumerable<TrendingCoinsOnCoinGecko> trendingCoins = null;
            using (var client = new HttpClient()) {
                 client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
                var responseTask = client.GetAsync("search/trending");

                responseTask.Wait();

                //TO DO

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {


                    var readJob = result.Content.ReadAsStringAsync();
                    var jsonSettings = new JsonSerializerSettings {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var stringResult = JsonConvert.DeserializeObject<Coins>(readJob.Result, jsonSettings);
                    
                    Console.WriteLine(stringResult);
                    return stringResult;
                }
               return null;

            }
        }*/

    
        
        [HttpGet]
        public List<Tweets> Tweets()
        {
            List<Tweets> tweets = new List<Tweets>();
            string mainConn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(mainConn);
            string sqlQuerryTweets = "SELECT * FROM Tweets";
            sqlConn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlQuerryTweets, sqlConn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlComm);
            DataTable dataTable = new DataTable();
            sdr.Fill(dataTable);
            foreach(DataRow dr in dataTable.Rows) {
                Tweets tw = new Tweets();
                tw.Tweetlink = dr["tweetlink"].ToString();
                tweets.Add(tw);
            }
            sqlConn.Close();
            return tweets;
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
