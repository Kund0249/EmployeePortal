using EmployeePortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Admin
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeList()
        {
            employeeRepository = new EmployeeRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //check if there is any QS
                if (Request.QueryString["dcode"] != null)
                {
                    if (!(
                            string.IsNullOrEmpty(Request.QueryString["dcode"]) &&
                            string.IsNullOrWhiteSpace(Request.QueryString["dcode"])
                          )
                        )
                    {
                        //int deptcode = Convert.ToInt32(Request.QueryString["dcode"]);

                        if(int.TryParse(Request.QueryString["dcode"],out int deptcode))
                        {
                            EmployeeGrid.DataSource = employeeRepository.GetEmployees(deptcode);
                            EmployeeGrid.DataBind();
                        }
                        else
                        {
                            EmployeeGrid.DataSource = employeeRepository.GetEmployees();
                            EmployeeGrid.DataBind();
                        }
                      
                    }
                }
                else
                {
                    EmployeeGrid.DataSource = employeeRepository.GetEmployees();
                    EmployeeGrid.DataBind();
                }
            }
        }

        protected void EmployeeGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void EmployeeGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}