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
    public class CreateNewRideModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Ride Ride { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<RideCategory> Categorys { get; set; } = new List<RideCategory>();
        public void OnGet()
        {
            Ride = new Ride();
            CategoryRepository categoryRepository = new CategoryRepository();
            Categorys = categoryRepository.GetAll();
        }
    }
}