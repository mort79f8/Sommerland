using Sommerland.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sommerland.DAL
{
    public class CategoryRepository : RepositoryBase
    {
        public List<RideCategory> GetAll()
        {
            string sql = "SELECT * FROM Rides";

            DataTable data = ExecuteQuery(sql);

            return HandleData(data);
        }

        public RideCategory GetCategory(int id)
        {
            string sql = $"SELECT * FROM RideCategories WHERE (RideCategoryId={id})";

            DataTable date = ExecuteQuery(sql);

            return HandleData(date).FirstOrDefault();
        }

        private List<RideCategory> HandleData(DataTable dataTable)
        {
            List<RideCategory> categories = new List<RideCategory>();

            foreach (DataRow row in dataTable.Rows)
            {
                RideCategory category = new RideCategory((int)row["RideCategoryId"], (string)row["Name"], (string)row["Description"]);
                categories.Add(category);
            }
            return categories;
        }
    }
}
