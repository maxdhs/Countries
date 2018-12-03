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


        [HttpPost("/countryMinPopulation")]
        public ActionResult minCreate(int countryMin)
        {
            List<Country> allCountries = Country.MinPopulationSize(countryMin);
            return View("Show", allCountries);
        }

        
        [HttpPost("/countryMaxPopulation")]
        public ActionResult maxCreate(int countryMax)
        {
            List<Country> allCountries = Country.MaxPopulationSize(countryMax);
            return View("Show", allCountries);
        }

    }
}
