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
    
    public class ClientsController : Controller
    {

        private ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Clients
        public ActionResult Index()
        {
            try
            {

                var client = _context.clients.ToList();
                if (client == null)
                {
                    return RedirectToAction("CreateClient");
                }

                return View(client);
            }
            catch
            {
                return RedirectToAction("CreateClient");
            }
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult CreateClient()
        {
            ClientsModel clientsModel = new ClientsModel();
           
            return View(clientsModel);
        }

        // POST: Captain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(ClientsModel clientsModel)
        {
            try
            {
                
                _context.clients.Add(clientsModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> EditClient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClient(int id, ClientsModel clientsModel)
        {
            if (id != clientsModel.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientsModel);
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

        public ActionResult DeleteClient(int id)
        {
            var clientToDelete = _context.clients.Where(s => s.ClientId == id).FirstOrDefault();
            return View(clientToDelete);
        }

        // POST: Captain/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClient(int id, ClientsModel clientsModel)
        {
            try
            {
                var clientToDelete = _context.clients.Find(id);
                _context.clients.Remove(clientToDelete);
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
