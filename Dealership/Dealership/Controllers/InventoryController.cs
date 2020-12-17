using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Controllers
{
    public class InventoryController : Controller
    {
        private readonly DealershipContext _context;
        public InventoryController(DealershipContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new SearchCriteria());
        }

        [HttpGet("Inventory/{id}")]
        public IActionResult Index(Vehicle.VehicleCondition id)
        {
            return View(new SearchCriteria(){ Condition = id });
        }

        public IActionResult Vehicle(string VIN)
        {
            return View("Vehicle", VIN);
        }

        public IActionResult SearchAjax(SearchCriteria searchCriteria)
        {
            return ViewComponent("Inventory", searchCriteria);
        }

        public IActionResult Searchbar(SearchCriteria searchCriteria)
        {
            return Json(searchCriteria.Make);
        }


    }
}