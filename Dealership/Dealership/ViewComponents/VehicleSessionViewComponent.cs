using Auer.Extensions;
using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.ViewComponents
{
    public class VehicleSessionViewComponent : ViewComponent
    {
        private readonly DealershipContext db;
        private readonly IWebHostEnvironment _env;
        public VehicleSessionViewComponent(DealershipContext context, IWebHostEnvironment env)
        {
            db = context;
            _env = env;
        }
        public async Task<IViewComponentResult> InvokeAsync(string VIN)
        {
            VehicleSession Session = await GetVehicleAsync(VIN);

            if (Session == null) {
                try { Session = HttpContext.Session.Get<VehicleSession>(); }
                catch (Exception) { return View("Card", new VehicleSession()); }
            }

            Session = GetImages(VIN, Session);

            return View("Card", Session);
        }

        private VehicleSession GetImages(string VIN, VehicleSession Session)
        {
            string dir = $"{_env.ContentRootPath}/wwwroot/cars/{VIN}";

            if (Directory.Exists(dir))
            {
                Session.VehicleFull.Images = new List<string>();
                DirectoryInfo d = new DirectoryInfo(dir);
                FileInfo[] infos = d.GetFiles();
                foreach (FileInfo f in infos)
                {
                    if (f.Name.StartsWith("default")) { continue; }
                    Session.VehicleFull.Images.Add($"/cars/{f.Directory.Name}/{f.Name}");
                }
            }
            return Session;
        }

        private async Task<VehicleSession> GetVehicleAsync(string VIN)
        {
            await Task.Run(() => Console.WriteLine("Task"));


            var query = from vehicle in db.Set<Vehicle>()
                        join full in db.Set<VehicleFullDB>()
                        on vehicle.VIN equals full.VIN
                        where vehicle.VIN == VIN
                        select new VehicleSession 
                        { 
                            Vehicle = vehicle, 
                            VehicleFull = VehicleFull.FromDB(full) 
                        };

            if (query.Any()) {
                return query.FirstOrDefault();
            }
            return null;
        }
    }
}
