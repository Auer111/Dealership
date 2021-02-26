using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Controllers
{
    public class ClientController : Controller
    {
        private readonly DealershipContext _context;
        private readonly ILogger<ClientController> _logger;
        private readonly IOptions<AppSettings> _settings;
        public ClientController(DealershipContext context, 
            ILogger<ClientController> logger, 
            IOptions<AppSettings> settings)
        {
            _context = context;
            _logger = logger;
            _settings = settings;
        }

        [HttpPost("Upload")]
        public IActionResult Upload(IFormFile file, string Username, string Password)
        {
            Account acc;
            try
            {
                string userId = _context.Users.Where(u => u.UserName == Username).First().Id;
                acc = _context.Accounts.Where(a => a.IdentityId == userId && a.CryptoPass == Password).First();
                acc.Dealer = _context.Dealers.Find(acc.DealerId);
                if (acc.Dealer == null) { throw new Exception(); }
    
                string filePath = Path.Combine(_settings.Value.UploadDirectory, file.Name + ".csv");
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            catch (Exception) { return NotFound(); }

            return new ContentResult { Content = acc.Dealer.Name, StatusCode = 200 };
        }

        [HttpPost("Login")]
        public IActionResult Login(string Username, string Password)
        {
            Account acc;
            try
            {
                string userId = _context.Users.Where(u => u.UserName == Username).First().Id;
                acc = _context.Accounts.Where(a => a.IdentityId == userId && a.CryptoPass == Password).First();
                acc.Dealer = _context.Dealers.Find(acc.DealerId);
                if (acc.Dealer == null) { throw new Exception(); }
            }
            catch (Exception) { return NotFound(); }



            return new ContentResult { Content = acc.Dealer.Name, StatusCode = 200 };
        }
    }
}
