using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EmployeePortal.Models;
using System.Configuration;
using EmployeePortal.Admin;
using System.Xml.Linq;

namespace EmployeePortal.Repositories
{
    public class DepartmentRepository
    {
        private string _connectionString;

        public DepartmentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EPSDBCON"].ConnectionString;
        }
        public void Save(DepartmentModel model)
        {
            //Step-1 Prepare Connection
            //string connectionString = "data source=DESKTOP-G3RV5V6;database=EPSDB;trusted_connection=true;TrustServerCertificate=true";
            //string connectionString = ConfigurationManager.ConnectionStrings["EPSDBCON"].ConnectionString;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                //Step-2 Prepare Command
                //string SqlQuery = $"spAddDepartment";
                SqlCommand command = new SqlCommand("spAddDepartment", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@code", model.Code);
                command.Parameters.AddWithValue("@DeptName", model.Name);
                command.Parameters.AddWithValue("@DeptDesc", model.Descriptions);

                //Step-3 Open the connection and execute query
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            //code 10 min
        }

        public string Update(DepartmentModel model)
        {
            string StatusCode = string.Empty;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("spUpdateDepartment", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DepartmentId", model.Id);
                command.Parameters.AddWithValue("@code", model.Code);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@Description", model.Descriptions);

              
                con.Open();
                StatusCode =  command.ExecuteScalar().ToString();
                con.Close();
            }
            return StatusCode;
           
        }
        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spGetAllDepartments", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        departments.Add(new DepartmentModel()
                        {
                            Id = Convert.ToInt32(reader["DeptId"]),
                            Code = reader["Code"].ToString(),
                            Name = reader["Name"].ToString(),
                            Descriptions = reader["Description"].ToString()
                        });
                    }
                }
            }

            return departments;
        }

        public void Remove(int departmentId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                //string SqlQuery = $"Delete from TDEPARTMENT where DeptId = {departmentId}";
                //SqlCommand cmd = new SqlCommand(SqlQuery, con);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //-------------------------------------------------------
                SqlCommand cmd = new SqlCommand("spDeleteDepartmentById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@departmentId", departmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DepartmentModel GetDepartment(int departmentId)
        {
            DepartmentModel model = new DepartmentModel();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDepartments", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

                con.Open();
                SqlDataReader datareader = cmd.ExecuteReader();
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        model.Id = Convert.ToInt32(datareader["DeptId"]);
                        model.Code = datareader["Code"].ToString();
                        model.Name = datareader["Name"].ToString();
                        model.Descriptions = datareader["Description"].ToString();
                    }
                }
            }

            return model;
        }
    }
}