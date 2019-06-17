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
        private List<Report> reports = new List<Report>();
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
            ImageUrl = imageUrl;
            ImageAltText = imageAltText;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public RideCategory Category { get => category; set => category = value; }
        public Status Status { get => status; set => status = value; }
        public IReadOnlyList<Report> Reports { get => reports.AsReadOnly(); }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public string ImageAltText { get => imageAltText; set => imageAltText = value; }
        public void Add(Report report)
        {
            report.Ride = this;
            reports.Add(report);

        }
        public void Add(List<Report> reports)
        {
            this.reports.AddRange(reports);

            //Another solution
            //foreach (Report report in reports)
            //{
            //    if (report.Ride != null && report.Ride.Id != this.Id)
            //    {

            //    }
            //    else
            //    {

            //        Add(report);
            //    }
            //}
        }
        public int NumberOfShutdowns()
        {
            List<Report> brokenReports = new List<Report>();

            foreach (var report in Reports)
            {
                if (report.Status == Status.Broken)
                {
                    brokenReports.Add(report);
                }
            }
            return brokenReports.Count;
        }

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
