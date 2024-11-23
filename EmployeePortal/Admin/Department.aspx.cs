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
        private readonly DepartmentRepository repository;

        public Department()
        {
            repository = new DepartmentRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataTable();
            }
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DepartmentModel model = new DepartmentModel()
                {
                    Code = txtDepartmentCode.Text,
                    Name = txtDepartmentName.Text,
                    Descriptions = txtDescription.Text
                };
                repository.Save(model);
                ResetForm();
                LoadDataTable();
            }
        }

        private void LoadDataTable()
        {
            DepartmentGrid.DataSource = repository.GetDepartments();
            DepartmentGrid.DataBind();
        }

        private void ResetForm()
        {
            txtDepartmentCode.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        protected void DepartmentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(DepartmentGrid.DataKeys[e.RowIndex].Value);
            repository.Remove(Id);
            LoadDataTable();
        }
    }
}