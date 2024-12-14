using EmployeePortal.Data;
using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmployeePortal.Repositories
{

    public class EmployeeRepository
    {
        private readonly EPSDBDataContext context;

        public EmployeeRepository()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["EPSDBConnectionString"].ConnectionString;

            context = new EPSDBDataContext(_connectionString);
        }
        public void Save(TEMPLOYEE employee)
        {
            context.TEMPLOYEEs.InsertOnSubmit(employee);
            context.SubmitChanges();
        }

        public List<EmployeeModel> GetEmployees()
        {
            
                //return context.TEMPLOYEEs.ToList();

                var EmployeeList = (from E in context.TEMPLOYEEs
                            join D in context.TDEPARTMENTs
                              on E.DepartmentId equals D.DeptId
                            select new EmployeeModel()
                            {
                                Name = E.Name,
                                Gender = E.Gender,
                                Email = E.Email,
                                Address = E.Address,
                                Mobile = E.Mobile,
                                Department = D.Name
                            }
                            ).ToList();
                return EmployeeList;
           
        }

        public List<EmployeeModel> GetEmployees(int departmentCode)
        {
            var EmployeeList = (from E in context.TEMPLOYEEs
                                join D in context.TDEPARTMENTs
                                  on E.DepartmentId equals D.DeptId
                                where D.DeptId == departmentCode
                                select new EmployeeModel()
                                {
                                    Name = E.Name,
                                    Gender = E.Gender,
                                    Email = E.Email,
                                    Address = E.Address,
                                    Mobile = E.Mobile,
                                    Department = D.Name
                                }
                           ).ToList();
            return EmployeeList;
        }
    }
}