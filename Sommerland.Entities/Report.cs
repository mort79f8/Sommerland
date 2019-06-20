using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sommerland.Entities
{
    public class Report
    {
        private int id;
        private Ride ride;
        private Status status;
        private DateTime reportTime;
        private string note;

        public Report()
        {
        }

        public Report(int id, Status status, DateTime reportTime, string note, Ride ride)
        {
            Id = id;
            Status = status;
            ReportTime = reportTime;
            Note = note;
            Ride = ride;
        }

        public int Id { get => id; set => id = value; }
        public Ride Ride { get => ride; set => ride = value; }
        public Status Status { get => status; set => status = value; }
        [DataType(DataType.DateTime)]
        public DateTime ReportTime { get => reportTime; set => reportTime = value; }
        public string Note { get => note; set => note = value; }
    }
}
