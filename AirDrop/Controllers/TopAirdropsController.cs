using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirDrop.Controllers
{
    public class TopAirdropsController : Controller
    {
        public IActionResult Index()
        {
            return Ok(DateTime.Now);
        }

        public IActionResult Brave()
        {
            return View();
        }
    }
}
