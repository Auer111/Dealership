using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IWebHostEnvironment _env;
        public AdminController(IWebHostEnvironment env) {
            _env = env;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadMultiple(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = _env.WebRootPath + "/cars";
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }
    }
}