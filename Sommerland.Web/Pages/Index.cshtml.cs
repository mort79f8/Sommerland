using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sommerland.DAL;
using Sommerland.Entities;
using Sommerland.Service;

namespace Sommerland.Web.Pages
{
    public class IndexModel : PageModel
    {
        private RideRepository rideRepository = new RideRepository();
        public List<Ride> rides { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<RideCategory> Categorys { get; set; } = new List<RideCategory>();
        public OpenWeatherMap Weather { get; set; } = new OpenWeatherMap();

        public void OnGet()
        {
            Weather.AppId = "3654de113ecd4a2bf4e4144d9403491b";
            Weather.City = "aalborg";
            CategoryRepository categoryRepository = new CategoryRepository();
            rides = rideRepository.GetAll();
            Categorys = categoryRepository.GetAll();
        }
    }
}