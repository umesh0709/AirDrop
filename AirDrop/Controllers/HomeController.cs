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

        public IActionResult Index()
        {

            /*list.CryptoInfo = _db.CryptoInfo.Take(5).ToList();
            list.Tweets = _db.Tweets.ToList();*/
            // IEnumerable<CryptoInfo> infoList = _db.CryptoInfo
            ViewBag.cryptoInfo = CryptoInfo();
            ViewBag.tweets = Tweets();
            return View();
        }

        [HttpGet]
        public List<CryptoInfo> CryptoInfo()
        {
            List<CryptoInfo> cryptoInfo = new List<CryptoInfo>();
            string mainConn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(mainConn);
            string sqlQuerryCryptoInfo = "SELECT * FROM CryptoInfo";
            sqlConn.Open();
            SqlCommand sqlComm = new SqlCommand(sqlQuerryCryptoInfo, sqlConn);
            SqlDataAdapter sdr = new SqlDataAdapter(sqlComm);
            DataTable dataTable = new DataTable();
            sdr.Fill(dataTable);
            foreach(DataRow dr in dataTable.Rows) {
                CryptoInfo cr = new CryptoInfo();
                cr.Name = dr["name"].ToString();
                cr.Info = dr["info"].ToString();
                cr.ParticipateLink = dr["participatelink"].ToString();
                cryptoInfo.Add(cr);
            }
            sqlConn.Close();
            return cryptoInfo;
        }

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
