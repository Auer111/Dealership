using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.ViewComponents
{
    public class SearchViewComponent : ViewComponent
    {
        private readonly DealershipContext _context;
        public SearchViewComponent(DealershipContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(SearchCriteria searchCriteria)
        {

            if (searchCriteria == null) { searchCriteria = new SearchCriteria(); }

            if (searchCriteria.BodyTypes == null) { searchCriteria.BodyTypes = BodyTypes.All; }
            if (searchCriteria.Colors == null) { searchCriteria.Colors = await _context.Colors.ToListAsync(); }
            if (searchCriteria.Makes == null) {
                searchCriteria.Makes = await _context.Makes.Select(make => new Make
                {
                    Name = make.Name,
                    Models = _context.Models.Where(mo => mo.MakeId == make.Id).ToList()
                }).ToListAsync();
            }
            return View(searchCriteria);
        }


    }
}
