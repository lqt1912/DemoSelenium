using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoSelenium.Models;

namespace DemoSelenium.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoSeleniumContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new DemoSeleniumContext();
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer cs)
        {
            if (ModelState.IsValid)
            {
                cs.Id = Guid.NewGuid();
                _context.Customer.Add(cs);
                _context.SaveChanges();
            }

            return RedirectToAction("CustomerList");
        }

        public IActionResult CustomerList()
        {
            return View(_context.Customer.ToList());
        }
    }
}
