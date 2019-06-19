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
    public class DisplayAddedRideModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ImageUrl { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ImageAltText { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool IsFormFilled { get; set; }
        [BindProperty(SupportsGet = true)]
        public Ride Ride { get; set; } = new Ride();
        [BindProperty(SupportsGet = true)]
        public bool IsSubmitted { get; set; } = false;
        public void OnGet()
        {
            CategoryRepository categoryRepositort = new CategoryRepository();

            if (Name == null || ImageUrl == null || ImageAltText == null || Description == null)
            {
                IsFormFilled = false;
            }
            else
            {
                IsFormFilled = true;
                Ride.Name = Name;
                Ride.Description = Description;
                Ride.Category = categoryRepositort.GetCategory(Category);
                Ride.ImageUrl = ImageUrl;
                Ride.ImageAltText = ImageAltText;
            }
        }
        public void OnGetVerified()
        {
            CategoryRepository categoryRepositort = new CategoryRepository();
            Ride.Category = categoryRepositort.GetCategory(Category);
            IsSubmitted = true;
        }

        public Dictionary<string, string> GetRideAsDictionary()
        {
            return new Dictionary<string, string>() {
                {"name", Ride.Name },
                {"category", Ride.Category.Id.ToString() },
                {"description", Ride.Description },
                {"imageUrl", Ride.ImageUrl },
                {"imageAltText", Ride.ImageAltText}
            };
        }
    }
}