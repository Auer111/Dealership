using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auer.Extensions;


namespace Dealership.ViewComponents
{
    public class InventoryViewComponent : ViewComponent
    {
        const int pageSize = 20;

        private readonly DealershipContext db;
        public InventoryViewComponent(DealershipContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(SearchCriteria Search)
        {
            if (Search == null) { return View(new Inventory { Vehicles = await GetItemsAsync() }); ; }

            Inventory Inv = await GetItemsFilteredAsync(Search);

            return View(Inv);
        }
        private async Task<List<Vehicle>> GetItemsAsync()
        {
            return await db.Vehicles.Take(pageSize).ToListAsync();
        }
        private async Task<Inventory> GetItemsFilteredAsync(SearchCriteria Search)
        {
            IQueryable<Vehicle> Vehicles = db.Vehicles;

            if (Search.Condition != Vehicle.VehicleCondition.Undefined) {
                Vehicles = Vehicles.Where(x => x.Condition == Search.Condition);
            }
            if (!string.IsNullOrWhiteSpace(Search.Make)) {
                Vehicles = Vehicles.Where(x => x.Make == Search.Make);
            }
            if (!string.IsNullOrWhiteSpace(Search.Model)) {
                Vehicles = Vehicles.Where(x => x.Model == Search.Model);
            }
            if (!string.IsNullOrWhiteSpace(Search.PriceMin.ToString()) &&
                !string.IsNullOrWhiteSpace(Search.PriceMax.ToString()))
            {
                Vehicles = Vehicles.Where(x => x.Price > Search.PriceMin && x.Price < Search.PriceMax);
            }
            if (!string.IsNullOrWhiteSpace(Search.Color)) {
                Vehicles = Vehicles.Where(x => x.Color == Search.Color);
            }

            int TotalPages = (int)Math.Ceiling(Vehicles.Count() / (double)pageSize);
            int TargetPage = GetPage(TotalPages, Search.Page);

            List<Vehicle> _v = await Vehicles.Skip((TargetPage -1) * pageSize).Take(pageSize).ToListAsync();

            return new Inventory()
            {
                Vehicles = _v,
                Page = TargetPage,
                PageTotal = TotalPages,
                hasPrevious = TargetPage > 1,
                hasNext = TargetPage < TotalPages
            };
        }
        private int GetPage(int TotalPages, int? Requested)
        {
            int Target = Requested ?? 1;
            int ClampedIndex = Target.Clamp(1, TotalPages);
            return ClampedIndex;
        }
    }
}
