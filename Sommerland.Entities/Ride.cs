using System;
using System.Collections.Generic;
using System.Text;

namespace Sommerland.Entities
{
    public class Ride
    {
        private int id;
        private string name;
        private string description;
        private RideCategory category;
        private Status status;
        private List<Report> reports;
        private string imageUrl;
        private string imageAltText;

        public Ride()
        {
        }

        public Ride(int id, string name, string description, RideCategory category, string imageUrl, string imageAltText)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Status = status;
            Reports = reports;
            ImageUrl = imageUrl;
            ImageAltText = imageAltText;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public RideCategory Category { get => category; set => category = value; }
        public Status Status { get => status; set => status = value; }
        public List<Report> Reports { get => reports; set => reports = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string ImageAltText { get => imageAltText; set => imageAltText = value; }

        //    public int NumberOfShutdowns()
        //    {
        //        throw NotImplementedException;
        //    }

        //    public int DaysSinceLastShutdown()
        //    {
        //        throw NotImplementedException;
        //    }

        public string GetShortDescription()
        {
            return Description.Substring(0, 47) + "...";
        }
    }
}
