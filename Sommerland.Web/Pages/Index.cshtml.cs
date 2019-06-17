using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sommerland.DAL;
using Sommerland.Entities;

namespace Sommerland.Web.Pages
{
    public class IndexModel : PageModel
    {
        private RideRepository rideRepository = new RideRepository();
        public List<Ride> rides { get; set; }
        public void OnGet()
        {
            rides = rideRepository.GetAll();
        }
    }
}