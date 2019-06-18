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
    public class SearchResultsModel : PageModel
    {
        private RideRepository rideRepository = new RideRepository();

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        [BindProperty(SupportsGet = true)]
        public Nullable<int> Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public Nullable<int> Status { get; set; }
        [BindProperty(SupportsGet = true)]
        public Ride Result { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<Ride> Results { get; set; }

        public void OnGet()
        {
            if (SearchName != null)
            {
                Result = SearchByName();                
            }
            else if (Category != null)
            {
                Results = SearchByCategory();
            }
            else if (Status != null)
            {
                Results = SearchByStatus();
            }

        }

        public Ride SearchByName()
        {
            var rideList = rideRepository.GetAll();
            foreach (var ride in rideList)
            {
                if (SearchName.ToLower() == ride.Name.ToLower())
                {
                    return ride;
                }
            }
            return new Ride();
        }

        public List<Ride> SearchByCategory()
        {
            List<Ride> rides = new List<Ride>();
            var rideList = rideRepository.GetAll();
            foreach (var ride in rideList)
            {
                if (Category == ride.Category.Id)
                {
                    rides.Add(ride);
                }
            }
            return rides;
        }

        public List<Ride> SearchByStatus()
        {
            List<Ride> rides = new List<Ride>();
            var rideList = rideRepository.GetAll();
            foreach (var ride in rideList)
            {
                if (Status == (int)ride.Status)
                {
                    rides.Add(ride);
                }
            }
            return rides;
        }
    }
}