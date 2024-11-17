using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EmployeePortal.Models;
using System.Configuration;

namespace EmployeePortal.Repositories
{
    public class DepartmentRepository
    {
        public void Save(DepartmentModel model)
        {
            //Step-1 Prepare Connection
            //string connectionString = "data source=DESKTOP-G3RV5V6;database=EPSDB;trusted_connection=true;TrustServerCertificate=true";
            string connectionString = ConfigurationManager.ConnectionStrings["EPSDBCON"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                //Step-2 Prepare Command
                string SqlQuery = $"Insert into TDEPARTMENT (Code,Name,Description) Values('{model.Code}','{model.Name}','{model.Descriptions}')";
                SqlCommand cmd = new SqlCommand(SqlQuery, con);

                //Step-3 Open the connection and execute query
                con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();
            }
            //code 10 min
        }
    }
}