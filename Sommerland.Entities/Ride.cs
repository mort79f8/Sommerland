using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Sommerland.Entities
{
    public class Ride
    {
        #region fields
        private int id;
        private string name;
        private string description;
        private RideCategory category;
        private List<Report> reports = new List<Report>();
        private string imageUrl;
        private string imageAltText;
        #endregion

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

        public Ride(string name, string description, RideCategory category, string imageUrl, string imageAltText)
        {
            Name = name;
            Description = description;
            Category = category;
            ImageUrl = imageUrl;
            ImageAltText = imageAltText;
        }

        public int Id { get => id; set => id = value; }
        [Display(Name="Navn")]
        public string Name { get => name; set => name = value; }
        [Display(Name = "Beskrivelse")]
        public string Description { get => description; set => description = value; }
        [Display(Name = "Kategori")]
        public RideCategory Category { get => category; set => category = value; }
        public Status Status { get
            {
                if (ReportsOrderedByDate.Count == 0)
                {
                    return Status.Working;
                }
                else
                {
                    return ReportsOrderedByDate[0].Status;
                }
            }
        }
        public IReadOnlyList<Report> Reports { get => reports.AsReadOnly(); }
        public IReadOnlyList<Report> ReportsOrderedByDate { get => reports.OrderByDescending(r => r.ReportTime).ToList().AsReadOnly(); }

        [Display(Name = "Billede sti")]
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        [Display(Name = "Billede alternative text")]
        public string ImageAltText { get => imageAltText; set => imageAltText = value; }

        public void Add(Report report)
        {
            report.Ride = this;
            reports.Add(report);

        }
        public void Add(List<Report> reports)
        {
            this.reports.AddRange(reports);
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

        public int DaysSinceLastShutdown()
        {
            //var orderedReports = Reports.OrderByDescending(r => r.ReportTime );
            var latestReport = ReportsOrderedByDate.FirstOrDefault();
            if (latestReport == null)
            {
                return -1;
            }
            TimeSpan timeSpan = DateTime.Now - latestReport.ReportTime;
            return timeSpan.Days;
        }

        public string GetShortDescription()
        {
            if (Description.Length < 47)
            {
                return Description;
            }
            return Description.Substring(0, 47) + "...";
        }
    }
}
