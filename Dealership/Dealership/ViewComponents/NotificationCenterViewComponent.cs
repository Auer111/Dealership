using Dealership.Data;
using Dealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.ViewComponents
{
    public class NotificationCenterViewComponent : ViewComponent
    {

        private readonly DealershipContext _context;
        public NotificationCenterViewComponent(DealershipContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            NotificationCenter Notification = new NotificationCenter
            {
                Notifications = await _context.Issues.ToListAsync()
            };
            return View(Notification);
        }
    }
}
