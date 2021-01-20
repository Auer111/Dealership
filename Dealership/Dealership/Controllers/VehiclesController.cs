using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Auer.Extensions;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using static Dealership.ViewComponents.VehicleViewComponent;
using Auer.Models;
using Auer.API;
using Auer.Data;
using Dealership.ViewComponents;
using Microsoft.AspNetCore.Http;

namespace Dealership.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly DealershipContext _context;
        private readonly IWebHostEnvironment _env;

        public VehiclesController(DealershipContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        public async Task<IActionResult> Preview(int id)
        {
            return View(await _context.Vehicles.Where(v => v.ID == id).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _context.Vehicles.Where(v => v.ID == id).FirstOrDefaultAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Vehicle vehicle)
        {
            try
            {
                Vehicle v = await _context.Vehicles.Where(v => v.ID == vehicle.ID).FirstOrDefaultAsync();
                if (v == null) { throw new Exception("Not found"); }

                VehicleFullDB vf = await _context.VehiclesFull.Where(vf => vf.VIN == v.VIN).FirstOrDefaultAsync();
                if (vf == null) { throw new Exception("Not found"); }

                _context.Vehicles.Remove(v);
                _context.VehiclesFull.Remove(vf);
                await _context.SaveChangesAsync();
            }
            catch (Exception) { return NotFound(); }

            return View(nameof(Index), await _context.Vehicles.ToListAsync());
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePreview(Vehicle vehicle)
        {
            try
            {
                VehicleSession session = SaveToSession(vehicle);
                return View("Vehicle", session.Vehicle);
            }
            catch (Exception) { return RedirectToAction(nameof(Index)); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NHTSAVinDecode(Vehicle vehicle)
        {
            ModelState.Clear();
            try
            {
                NHTSAVehicleFull NVF = (await NHTSAClient.GetVehicleData(vehicle.VIN)).Results.First();
                vehicle.Make = NVF.Make; vehicle.Model = NVF.Model; vehicle.Trim = NVF.Trim; vehicle.Year = int.Parse(NVF.ModelYear);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "NHTSA vPIC API is under Maintenence try again later.");
            }
            return View("Vehicle", vehicle);
        }

        public IActionResult Vehicle(string VIN)
        {
            ModelState.Clear();
            VehicleSession session = new VehicleSession();
            session.Session = VehicleSession.SessionType.Create;
            try
            {
                if (VIN != null)
                {
                    var query = from vehicle in _context.Set<Vehicle>()
                                join full in _context.Set<VehicleFullDB>()
                                on vehicle.VIN equals full.VIN
                                where vehicle.VIN == VIN
                                select new VehicleSession
                                {
                                    Session = VehicleSession.SessionType.Edit,
                                    Vehicle = vehicle,
                                    VehicleFull = Models.VehicleFull.FromDB(full)
                                };

                    if (query.Any())
                    {
                        session = query.FirstOrDefault();
                    }
                }
            }
            catch (Exception) { return RedirectToAction(nameof(Index)); };

            HttpContext.Session.Set(session);
            return View("Vehicle", session.Vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vehicle(Vehicle vehicle)
        {
            try
            {
                VehicleSession session = SaveToSession(vehicle);
                if (ModelState.IsValid)
                {
                    return View("VehicleFull", session);
                }
                return View("Vehicle", session.Vehicle);
            }
            catch (Exception) { return RedirectToAction(nameof(Index)); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NHTSAFull(string VIN)
        {
            NHTSAVehicleFullWrapper VFW = await NHTSAClient.GetVehicleData(VIN);

            List<KVP> Items = VFW.Results.First().GetDataList();

            return Json(new { keys = Items.Select(i => i.Name), values = Items.Select(i => i.Value) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VehicleFullBack(VehicleFull full)
        {
            try
            {
                VehicleSession session = SaveToSession(full);
                if (ModelState.IsValid)
                {
                    return View("Vehicle", session.Vehicle);
                }
                return View("VehicleFull", session);

            }
            catch (Exception) { return RedirectToAction(nameof(Index)); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePreviewFull(VehicleFull full)
        {
            try
            {
                VehicleSession session = SaveToSession(full);
                return View("VehicleFull", session);
            }
            catch (Exception) { return RedirectToAction(nameof(Index)); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleFull(VehicleFull full)
        {
            try
            {
                VehicleSession session = SaveToSession(full);
                if (ModelState.IsValid)
                {
                    using (var dbContextTransaction = _context.Database.BeginTransaction())
                    {

                        if (session.Session == VehicleSession.SessionType.Edit && VehicleExists(session.Vehicle.VIN))
                        {
                            Vehicle v = await _context.Vehicles.FirstOrDefaultAsync(v => v.VIN == session.Vehicle.VIN);
                            v.GetUpdates(session.Vehicle);
                            _context.Vehicles.Update(v);

                            VehicleFullDB vfdb = await _context.VehiclesFull.FirstOrDefaultAsync(f => f.VIN == session.VehicleFull.VIN);
                            vfdb.GetUpdates(session.VehicleFull.ToDB());
                            _context.VehiclesFull.Update(vfdb);
                        }
                        else if (session.Session == VehicleSession.SessionType.Create && !VehicleExists(session.Vehicle.VIN))
                        {
                            _context.Vehicles.Add(session.Vehicle);
                            _context.VehiclesFull.Add(session.VehicleFull.ToDB());
                        }
                        if (!_context.Makes.Any(m => m.Name == session.Vehicle.Make)) { _context.Makes.Add(new Make { Name = session.Vehicle.Make }); }
                        if (!_context.Colors.Any(c => c.Name == session.Vehicle.Color)) { _context.Colors.Add(new BodyColor { Name = session.Vehicle.Color }); }
                        await _context.SaveChangesAsync();

                        long _id = _context.Makes.FirstOrDefault(m => m.Name == session.Vehicle.Make).ID;
                        if (!_context.Models.Any(mo => mo.MakeID == _id && mo.Name == session.Vehicle.Model)) { _context.Models.Add(new Model { Name = session.Vehicle.Model, MakeID = _id }); }
                        await _context.SaveChangesAsync();

                        dbContextTransaction.Commit();
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View("VehicleFull", session);
            }
            catch (Exception ex)
            { return RedirectToAction(nameof(Index)); }
        }


        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file, string VIN)
        {
            if (string.IsNullOrWhiteSpace(VIN) || VIN.Length < 5) { return BadRequest("VIN cannot be null"); }
            if (file == null || file.Length < 1) { return BadRequest("File cannot be null"); }

            string webPath = "";
            try
            {
                if (file != null)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string directory = _env.WebRootPath + $"/cars/{VIN}";
                    string filePath = $"{directory}/default{extension}";
                    webPath = $"/cars/{VIN}/default{extension}";

                    System.IO.Directory.CreateDirectory(directory);

                    if (System.IO.File.Exists(Path.Combine(filePath)))
                    {
                        System.IO.File.Delete(Path.Combine(filePath));
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            catch (Exception) { return StatusCode(500, "Error Saving Image"); }
            return Ok(webPath);
        }

        [HttpPost]
        public async Task<ActionResult> UploadFiles(List<IFormFile> files, string VIN)
        {
            if (string.IsNullOrWhiteSpace(VIN) || VIN.Length < 5) { return BadRequest("VIN cannot be null"); }
            if (files == null || !files.Any()) { return BadRequest("Files cannot be null"); }


            List<string> webPaths = new List<string>();
            foreach (IFormFile file in files)
            {
                string webPath = "";
                try
                {
                    if (file != null && file.Length > 1)
                    {
                        string fName = Path.GetRandomFileName();

                        string extension = Path.GetExtension(file.FileName);
                        string directory = _env.WebRootPath + $"/cars/{VIN}";
                        string filePath = $"{directory}/{fName}{extension}";
                        webPath = $"/cars/{VIN}/{fName}{extension}";

                        System.IO.Directory.CreateDirectory(directory);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        webPaths.Add(webPath);
                    }
                }
                catch (Exception) { return StatusCode(500, "Error Saving Image"); }
            }
            return Json(webPaths);
        }


        #region Methods
        private bool VehicleExists(string VIN)
        {
            return _context.Vehicles.Any(e => e.VIN == VIN);
        }
        public VehicleSession SaveToSession(Vehicle v)
        {
            ModelState.Clear();
            VehicleSession session = HttpContext.Session.Get<VehicleSession>();
            session.Vehicle = v;
            session.VehicleFull.VIN = session.Vehicle.VIN;
            HttpContext.Session.Set(session);
            return session;
        }
        public VehicleSession SaveToSession(VehicleFull vf)
        {
            ModelState.Clear();
            VehicleSession session = HttpContext.Session.Get<VehicleSession>();
            session.VehicleFull = vf;
            HttpContext.Session.Set(session);
            return session;
        }
        #endregion

        
        
    }
}
