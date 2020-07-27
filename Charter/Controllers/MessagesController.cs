using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charter.Data;
using Charter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Charter.Controllers
{
    public class MessagesController : Controller
    {

        private ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Messages
        public ActionResult Index()
        {
            var messageList = _context.messages.ToList();
            return View(messageList);
        }

       

        // GET: Messages/Create
        public ActionResult CreateMessage()
        {
            MessagesModel messagesModel = new MessagesModel();
            return View(messagesModel);
        }

        // POST: Messages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMessage(MessagesModel messagesModel)
        {
            try
            {
                _context.messages.Add(messagesModel);
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