using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Charter.Data;
using Charter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PayPal.Api;

namespace Charter.Controllers
{
    [Authorize(Roles = "Captain")]
    public class CaptainsController : Controller
    {

        private ApplicationDbContext _context;

        public CaptainsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Captain
        public ActionResult Index()
        {

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var captain = _context.captains.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                if (captain == null)
                {
                    return RedirectToAction("CreateCaptain");
                }

                return View(captain);
            }
            catch
            {
                return RedirectToAction("CreateCaptain");
            }
        }
        public ActionResult BoatDetails(int id)
        {
            var boat = _context.boats.Where(h => h.BoatId == id).SingleOrDefault();
            return View(boat);
        }
        // GET: Captain/Create
        public ActionResult CreateBoat()
        {
            BoatsModel boatsModel = new BoatsModel();
            return View(boatsModel);
        }

        // POST: Captain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBoat(BoatsModel boatsModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var captId = _context.captains.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                boatsModel.CaptainId = captId.CaptainId;
                _context.boats.Add(boatsModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateBait()
        {
            BaitsModel baitsModel = new BaitsModel();
            return View(baitsModel);
        }

        // POST: Captain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBait(BaitsModel baitsModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var captId = _context.captains.Where(c => c.IdentityUserId == userId).SingleOrDefault();
                baitsModel.CaptainId = captId.CaptainId;
                _context.baits.Add(baitsModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Captain/Create
        public ActionResult CreateCaptain()
        {
            CaptainsModel captainsModel = new CaptainsModel();
            return View(captainsModel);
        }

        // POST: Captain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCaptain(CaptainsModel captainsModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                captainsModel.IdentityUserId = userId;
                _context.captains.Add(captainsModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreateInsurance()
        {
            InsurancesModel insurancesModel = new InsurancesModel();
            return View(insurancesModel);
        }

        // POST: Captain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInsurance(InsurancesModel insurancesModel)
        {
            try
            {
               
                _context.insurances.Add(insurancesModel);
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> EditCaptain(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.captains.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCaptain(int id, CaptainsModel captainsModel)
        {
            if (id != captainsModel.CaptainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(captainsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Index");
            }

            // return View(captainsModel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditBait(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.baits.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBait(int id, BaitsModel baitsModel)
        {
            if (id != baitsModel.CaptainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baitsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Index");
            }

            // return View(captainsModel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditBoat(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.boats.FindAsync(id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBoat(int id, BoatsModel boatsModel)
        {
            if (id != boatsModel.BoatId)
            {
                return NotFound();
            }
            
            
            if (ModelState.IsValid)
            {
                try
                {
                    var engineHours = _context.boats.AsNoTracking().Where(b => b.BoatId == id).FirstOrDefault();
                    if (boatsModel.EngineHours != engineHours.EngineHours)
                    {
                        boatsModel.EngineHours += engineHours.EngineHours;
                    }
                    if (boatsModel.UsageAmountHours != engineHours.UsageAmountHours)
                    {
                        boatsModel.UsageAmountHours += engineHours.UsageAmountHours;
                    }
                    if (boatsModel.GasCotst != engineHours.GasCotst)
                    {
                        boatsModel.GasCotst += engineHours.GasCotst;
                    }
                    
                    _context.Update(boatsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Index");
            }

            // return View(captainsModel);
            return RedirectToAction("Index");
        }
        // GET: Captain/Delete/5
        public ActionResult DeleteCaptain(int id)
        {
            var captainToDelete = _context.captains.Where(s => s.CaptainId == id).FirstOrDefault();
            return View(captainToDelete);
        }

        // POST: Captain/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCaptain(int id, CaptainsModel captainsModel)
        {
            try
            {
                var captainToDelete = _context.captains.Find(id);
                _context.captains.Remove(captainToDelete);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteBoat(int id)
        {
            var boatToDelete = _context.boats.Where(s => s.BoatId == id).FirstOrDefault();
            return View(boatToDelete);
        }

        // POST: Captain/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBoat(int id, BoatsModel boatsModel)
        {
            try
            {
                var boatToDelete = _context.boats.Find(id);
                _context.boats.Remove(boatToDelete);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> GetTide(int? id, CaptainsModel captainsModel)
        {
            var captain = _context.captains.Where(c => c.CaptainId == id).FirstOrDefault();
            HttpClient httpClient = new HttpClient();
            var url =
                string.Format(
                    "https://tidesandcurrents.noaa.gov/api/datagetter?date=today&station={0}&product=predictions&datum=msl&units=english&time_zone=gmt&application=web_services&format=json&interval=hilo",captain.TideStationId);

            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject parsedJson = JObject.Parse(jsonResponse);
                var predictions = parsedJson["predictions"].ToArray();

                TidePredictionViewModel tidePredictionViewModel = new TidePredictionViewModel();
                tidePredictionViewModel.Time = new List<String>();
                tidePredictionViewModel.Height = new List<String>();
                tidePredictionViewModel.Tide = new List<String>();


                for (int i = 0; i < predictions.Length; i++)
                {
                    var vdata = predictions[i]["t"].ToString();
                    var height = predictions[i]["v"].ToString();
                    var tide = predictions[i]["type"].ToString();

                    tidePredictionViewModel.Time.Add(vdata);
                    tidePredictionViewModel.Height.Add(height);
                    tidePredictionViewModel.Tide.Add(tide);
                }
                return View(tidePredictionViewModel);
            }
            else
            {
                return View();
            }

                
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
                var weather = parsedJson["list"].ToArray();

                var mainTemp = weather[0]["main"]["temp"].ToString();
                var feelsLike = weather[0]["main"]["feels_like"].ToString();
                var maxTemp = weather[0]["main"]["temp_max"].ToString();
                var pressure = weather[0]["main"]["pressure"].ToString();
                var seaLevel = weather[0]["main"]["sea_level"].ToString();
                var windSpeed = weather[0]["wind"]["speed"].ToString();
                //var description = weather[0]["weather"]["description"].ToString();

                WeatherViewModel weatherViewModel = new WeatherViewModel();
                weatherViewModel.mainTemp = mainTemp;
                weatherViewModel.feelsLike = feelsLike;
                weatherViewModel.maxTemp = maxTemp;
                weatherViewModel.pressure = pressure;
                weatherViewModel.seaLevel = seaLevel;
                weatherViewModel.windSpeed = windSpeed;

                return View(weatherViewModel);
            }
            else
            {
                return View();
            }


        }
    }
}