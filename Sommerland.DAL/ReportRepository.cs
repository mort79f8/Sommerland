using Sommerland.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sommerland.DAL
{
    public class ReportRepository : RepositoryBase
    {
        public List<Report> GetAll()
        {
            string sql = "SELECT * FROM Rides";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }

        public List<Report> GetReportFromRideId(int rideId)
        {
            string sql = $"SELECT * FROM Reports WHERE (RideId={rideId})";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }
        public List<Report> GetReportFromRide(Ride ride)
        {
            string sql = $"SELECT * FROM Reports WHERE (RideId={ride.Id})";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data, ride);
        }

        public List<Report> GetReportsFromRideIdAndStatus(int rideId, int status)
        {
            string sql = $"SELECT * FROM Reports WHERE ((RideId={rideId}) AND (Status = {status}))";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }

        private List<Report> HandleData(DataTable dataTable, Ride ride = null)
        {
            List<Report> reports = new List<Report>();

            foreach (DataRow row in dataTable.Rows)
            {
                Report report = new Report((int)row["ReportId"],(Status)row["Status"],(DateTime)row["ReportTime"],(string)row["Notes"], ride);
                reports.Add(report);
            }
            return reports;
        }
    }
}
