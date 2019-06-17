using Sommerland.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sommerland.DAL
{
    public class RideRepository : RepositoryBase
    {
        private CategoryRepository category = new CategoryRepository();
        public List<Ride> GetAll()
        {
            string sql = "SELECT * FROM Rides";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }

        private List<Ride> HandleData(DataTable dataTable)
        {
            List<Ride> rides = new List<Ride>();

            foreach (DataRow row in dataTable.Rows)
            {
                Ride ride = new Ride((int)row["RideId"], (string)row["Name"], (string)row["Description"], category.GetCategory((int)row["CategoryId"]), (string)row["ImageUrl"],(string)row["ImageAltText"]);
                rides.Add(ride);
            }
            return rides;
        }

    }
}
