using Charter.Data;
using Charter.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Charter.Controllers
{
    public class WeatherController : Controller
    {
        private ApplicationDbContext _context;

        public WeatherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> GetWeather(int? id, CaptainsModel captainsModel)
        {
            var captain = _context.captains.Where(c => c.CaptainId == id).FirstOrDefault();
            HttpClient httpClient = new HttpClient();
            var url =
                string.Format(
                    "https://api.openweathermap.org/data/2.5/forecast?zip={0},us&units=imperial&APPID=7d525b2a241057a21adda993b263df5f", captain.ZipCode);

            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject parsedJson = JObject.Parse(jsonResponse);
                var predictions = parsedJson["list"].ToArray();

               
                return View(predictions);
            }
            else
            {
                return View();
            }


        }
    }
}
