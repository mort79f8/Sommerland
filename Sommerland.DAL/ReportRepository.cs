using Sommerland.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sommerland.DAL
{
    public class ReportRepository : RepositoryBase
    {
        private RideRepository rideRepository = new RideRepository();
        public List<Report> GetAll()
        {
            string sql = "SELECT * FROM Rides";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }

        private List<Report> HandleData(DataTable dataTable)
        {
            List<Report> reports = new List<Report>();

            foreach (DataRow row in dataTable.Rows)
            {
                Report report = new Report((int)row["ReportId"],(Status)row["Status"],(DateTime)row["ReportTime"],(string)row["Notes"],rideRepository.GetRide((int)row["RideId"]));
                reports.Add(report);
            }
            return reports;
        }
    }
}
