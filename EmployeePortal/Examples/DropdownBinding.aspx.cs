using EmployeePortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Examples
{
    public partial class DropdownBinding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepartmentRepository repository = new DepartmentRepository();
                var data = repository.GetDepartments();
                //data.Insert(0, new Models.DepartmentModel() { Id = -1, Name = "Select Department" });
                ddlCategory.DataSource = data;
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem()
                {
                    Text = "Select Department",
                    Value = "-1"
                });
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string selectedDepartmentId = ddlCategory.SelectedValue;
            ddlCategory.ClearSelection();
        }
    }
}