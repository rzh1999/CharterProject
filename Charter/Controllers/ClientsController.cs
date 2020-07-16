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
            AddressModel addressModel = new AddressModel();
            return View(clientsModel);
        }

        // POST: Captain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(ClientsModel clientsModel, AddressModel addressModel)
        {
            try
            {
                //_context.address.Add(addressModel);
                //_context.SaveChanges();
                //clientsModel.AddressId = addressModel.AddressId;
                _context.clients.Add(clientsModel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit/5
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

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clients/Delete/5
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