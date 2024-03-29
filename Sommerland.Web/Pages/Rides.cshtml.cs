﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sommerland.DAL;
using Sommerland.Entities;

namespace Sommerland.Web.Pages
{
    public class RidesModel : PageModel
    {

        private int rideId;
        private Ride ride = new Ride();
        private RideRepository rideRepository = new RideRepository();

        [BindProperty(SupportsGet = true)]
        public int RideId { get => rideId; set => rideId = value; }
        [BindProperty]
        public Report Report { get; set; }
        public Ride Ride { get => ride; set => ride = value; }

        public void OnGet()
        {
            InitializeRide();
        }

        public void OnPostVerified()
        {
            InitializeRide();
            ride.Add(Report);
            ReportRepository reportRepository = new ReportRepository();
            reportRepository.Insert(Report);
        }

        private void InitializeRide()
        {
            ride = rideRepository.GetRide(RideId);
        }
    }
}