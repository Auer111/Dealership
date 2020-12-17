using Auer.Api;
using Auer.API;
using Auer.Models;
using Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading.Tasks;

namespace Dealership.ViewComponents
{

    
    public class VehicleViewComponent : ViewComponent
    {
        public VehicleViewComponent() {   }

        public async Task<IViewComponentResult> InvokeAsync(Vehicle vehicle)
        {
            await Task.Run(() => Console.WriteLine("Async"));
            if (vehicle.VIN == null) { vehicle.VIN = ""; }
            return View("Card", vehicle);
        }

    }
}
