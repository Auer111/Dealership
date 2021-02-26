using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dealership.Models;
using Microsoft.AspNetCore.Http;
using Dealership.Data;

namespace Dealership.Controllers
{
    public class HomeController : Controller
    {
        private readonly DealershipContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DealershipContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult GetContact()
        {
            return View("Contact", new ContactViewModel());
        }

        [HttpPost("Contact")]
        public IActionResult PostContact(ContactViewModel model)
        {
            model.Sent = true;
            return View("Contact", model);
        }

        [HttpGet("About")]
        public IActionResult GetAbout()
        {
            return View("About");
        }

        
    }
}
