using AirDrop.Models;
using AirDropML.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirDrop.Controllers
{
    public class PredictionController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }

        
        public IActionResult bitcoin()
        {
            
            

            return View();
        }

        [HttpPost]
        public IActionResult Index(ModelInput input)
        {
            List<DataPoints> dataPoints = new List<DataPoints>();

            ViewBag.Result = "";
            var prediction = ConsumeModel.Predict(input);
            ViewBag.Result = prediction;

            
            
            ViewData["Open"] = input.Open;
            ViewData["High"] = input.High;
            ViewData["Low"] = input.Low;
            dataPoints.Add(new DataPoints("Predictied Price", ViewBag.Result.Score));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }

       
    }
}
