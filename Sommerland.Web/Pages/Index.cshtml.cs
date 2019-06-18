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
        [BindProperty(SupportsGet = true)]
        public List<RideCategory> Categorys { get; set; } = new List<RideCategory>();

        public void OnGet()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            rides = rideRepository.GetAll();
            Categorys = categoryRepository.GetAll();
        }
    }
}