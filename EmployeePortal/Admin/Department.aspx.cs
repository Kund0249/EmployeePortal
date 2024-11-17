using EmployeePortal.Models;
using EmployeePortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Admin
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentModel model = new DepartmentModel()
            {
                Code = txtDepartmentCode.Text,
                Name = txtDepartmentName.Text,
                Descriptions = txtDescription.Text
            };
            DepartmentRepository repository = new DepartmentRepository();
            repository.Save(model);
        }
    }
}