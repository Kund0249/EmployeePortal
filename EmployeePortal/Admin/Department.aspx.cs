using EmployeePortal.Constant;
using EmployeePortal.Models;
using EmployeePortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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

                if (!(string.IsNullOrEmpty(hdfDeptId.Value) &&
                    string.IsNullOrWhiteSpace(hdfDeptId.Value))
                    )
                {
                    model.Id = Convert.ToInt32(hdfDeptId.Value);
                    var statuscode = repository.Update(model);
                    if (statuscode == AppStatusCode.Success)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(),
                            "Al01",
                            "toastr[\"success\"](\"Record updated\", \"Success\")",
                            true);
                    }
                    else if (statuscode == AppStatusCode.Exists)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(),
                            "Al01",
                            "toastr[\"info\"](\"Department code already exists.\", \"Info\")",
                            true);
                    }
                }
                else
                {
                    repository.Save(model);
                    ClientScript.RegisterClientScriptBlock(this.GetType(),
                            "Al01",
                            "toastr[\"success\"](\"Record created\", \"Success\")",
                            true);
                }


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
            hdfDeptId.Value = null;
        }

        protected void DepartmentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt32(DepartmentGrid.DataKeys[e.RowIndex].Value);
            repository.Remove(Id);
            LoadDataTable();
        }

        protected void DepartmentGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(DepartmentGrid.DataKeys[DepartmentGrid.SelectedIndex].Value);
            DepartmentModel model = repository.GetDepartment(Id);

            txtDepartmentCode.Text = model.Code;
            txtDepartmentName.Text = model.Name;
            txtDescription.Text = model.Descriptions;
            hdfDeptId.Value = model.Id.ToString();
        }
    }
}