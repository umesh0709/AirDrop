using AirDrop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirDrop.Controllers
{
    public class CryptosController : Controller
    {
        public IActionResult Index()
        {
            // return View();

            ViewBag.cryptoList = GetCurrencyData();
            return View();
        }

        public List<CryptoCurrencyData> GetCurrencyData()
        {
            List<CryptoCurrencyData> currency = new List<CryptoCurrencyData>();

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://api.nomics.com/v1/");
                var responseTask = client.GetAsync("currencies/ticker?key=60554f1aac4ec6ecf9d934a78719834f353163ae&&interval=1d&per-page=20&page=1"
                   );
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) {
                    Task<string> json = result.Content.ReadAsStringAsync();
                  //  dynamic currencyData = JsonConvert.DeserializeObject<List<CryptoCurrencyData>>(json.Result);
                    List<CryptoCurrencyData> currencyData = JsonConvert.DeserializeObject<List<CryptoCurrencyData>>(json.Result);
                    return currencyData;
                }
            }
            return null;
        }



    }
}
