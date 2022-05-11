using AirDropML.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public IActionResult Index(ModelInput input)
        {
            ViewBag.Result = "";
            var prediction = ConsumeModel.Predict(input);
            ViewBag.Result = prediction;

            ViewData["Date"] = input.Date;
            ViewData["Open"] = input.Open;
            ViewData["High"] = input.High;
            ViewData["Low"] = input.Low;
            return View();
        }
    }
}
