using EmployeePortal.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace EmployeePortal.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            EPSDBDataContext context =
                 new EPSDBDataContext(ConfigurationManager.
                 ConnectionStrings["EPSDBConnectionString"]
                 .ConnectionString);

            if (ViewState["AttemptsCount"] == null)
                ViewState["AttemptsCount"] = 0;

            string EmailAddress = txtEmail.Text.ToLower();
            string Password = txtpasswor.Text;
            var userdetails = context.TUSERs.SingleOrDefault
                (x => x.EmailAddress.ToLower() == EmailAddress);

            if (userdetails == null)
            {
                lblError.Text = "Inavlid Email and Password!";
                return;
            }

            if (userdetails.IsLocked != null && Convert.ToBoolean(userdetails.IsLocked))
            {
                lblError.Text = "User account is locked for the security purpose. try after 24 hrs.";
                return;
            }

            if (Convert.ToInt32(ViewState["AttemptsCount"]) <= 2)
            {
                if (userdetails.Password == Password)
                {
                    FormsAuthentication.RedirectFromLoginPage(EmailAddress, false);
                }
                else
                {
                    ViewState["AttemptsCount"] = (Convert.ToInt32(ViewState["AttemptsCount"]) + 1);
                    lblError.Text = "Invalid Email or Password!.";
                }
            }
            else
            {
                lblError.Text = "User account is locked for the security purpose. try after 24 hrs.";
                userdetails.IsLocked = true;
                userdetails.AccountLockOn = DateTime.Now;
                context.SubmitChanges();
            }


        }
    }
}