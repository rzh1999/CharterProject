using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Charter.Models;
using Stripe;

namespace Charter.Controllers
{
    public class HomeController : Controller
    {
        public readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChargeHalfDay(string stripeEmail, string stripeToken) {
            var customers = new CustomerService();
            var charges = new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions{
               Email=stripeEmail,
               Source= stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount= 45000,
                Description="Half Day Trip",
                Currency="usd",
                Customer=customer.Id,
                ReceiptEmail=stripeEmail
            });

            if (charge.Status == "succed")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return View();
            }
            else
            {

            }
            return View();
        }
        public IActionResult ChargeFullDay(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 67500,
                Description = "Full Day Trip",
                Currency = "usd",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail
            });

            if (charge.Status == "succed")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return View();
            }
            else
            {

            }
            return View();
        }
    }
}
