using Sommerland.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sommerland.DAL
{
    public class RideRepository : RepositoryBase
    {
        private CategoryRepository category = new CategoryRepository();
        private ReportRepository reports = new ReportRepository();
        public List<Ride> GetAll()
        {
            string sql = "SELECT * FROM Rides";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }

        public Ride GetRide(int id)
        {
            string sql = $"SELECT * FROM Rides WHERE (RideId={id})";

            DataTable date = ExecuteQuery(sql);

            return HandleData(date).FirstOrDefault();
        }

        private List<Ride> HandleData(DataTable dataTable)
        {
            List<Ride> rides = new List<Ride>();

            foreach (DataRow row in dataTable.Rows)
            {
                Ride ride = new Ride((int)row["RideId"], (string)row["Name"], (string)row["Description"], category.GetCategory((int)row["CategoryId"]), (string)row["ImageUrl"],(string)row["ImageAltText"]);
                ride.Add(reports.GetReportFromRide(ride));
                rides.Add(ride);
            }
            return rides;
        }

        public int Insert(Ride ride)
        {
                string sql = $"INSERT INTO Rides VALUES ('{ride.Name}', '{ride.Description}','{ride.Category.Id}', '{ride.ImageUrl}', '{ride.ImageAltText}')";

                return ExecuteNonQuery(sql);
        }
    }
}
