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

        // GET: Captain/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Captain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Captain/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Captain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Captain/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}