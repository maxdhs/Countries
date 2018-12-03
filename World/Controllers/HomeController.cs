using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Country> allCountries = Country.GetAll();
            return View(allCountries);
        }

        [HttpPost("/country")]
        public ActionResult Create(string countryName)
        {
            List<Country> allCountries = Country.FilterCountryName(countryName);
            return View("Show", allCountries);
        }

    }
}
