using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Charter.Data;
using Charter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}