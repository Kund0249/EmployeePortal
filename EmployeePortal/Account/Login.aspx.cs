using EmployeePortal.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Runtime.Remoting.Contexts;

namespace EmployeePortal.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie ck = Request.Cookies["usercredentials"];
                if(ck != null)
                {
                    string EmailAddress = ck["UserId"].ToString();
                    string Password = ck["password"].ToString();

                    if (IsValid(EmailAddress,Password,out TUSER userdetails))
                    {
                        if (userdetails.IsLocked != null && Convert.ToBoolean(userdetails.IsLocked))
                        {
                            lblError.Text = "User account is locked for the security purpose. try after 24 hrs.";
                            return;
                        }
                        else
                        {
                            Session["CurrentUserName"] = userdetails.FullName;
                            FormsAuthentication.RedirectFromLoginPage(EmailAddress, false);
                        }

                    }
                }
            }
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {


            if (ViewState["AttemptsCount"] == null)
                ViewState["AttemptsCount"] = 0;

            string EmailAddress = txtEmail.Text.ToLower();
            string Password = txtpasswor.Text;


            if (IsValid(EmailAddress, Password, out TUSER userdetails))
            {
                if (userdetails.IsLocked != null && Convert.ToBoolean(userdetails.IsLocked))
                {
                    lblError.Text = "User account is locked for the security purpose. try after 24 hrs.";
                    return;
                }

                if (chkRemberme.Checked)
                {
                    HttpCookie ck = new HttpCookie("usercredentials");
                    ck["UserId"] = userdetails.EmailAddress;
                    ck["password"] = userdetails.Password;
                    ck.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Add(ck);
                }
                Session["CurrentUserName"] = userdetails.FullName;
                FormsAuthentication.RedirectFromLoginPage(EmailAddress, false);
            }
            else
            {
                lblError.Text = "Inavlid Email and Password!";
                return;
            }

            //lblError.Text = "User account is locked for the security purpose. try after 24 hrs.";
            //userdetails.IsLocked = true;
            //userdetails.AccountLockOn = DateTime.Now;
            //context.SubmitChanges();






            //if (Convert.ToInt32(ViewState["AttemptsCount"]) <= 2)
            //{
            //    if (userdetails.Password == Password)
            //    {
            //        if (chkRemberme.Checked)
            //        {
            //            HttpCookie ck = new HttpCookie("usercredentials");
            //            ck["UserId"] = userdetails.EmailAddress;
            //            ck["password"] = userdetails.Password;
            //            ck.Expires = DateTime.Now.AddDays(2);
            //           Response.Cookies.Add(ck);
            //        }

            //        FormsAuthentication.RedirectFromLoginPage(EmailAddress, false);
            //    }
            //    else
            //    {
            //        ViewState["AttemptsCount"] = (Convert.ToInt32(ViewState["AttemptsCount"]) + 1);
            //        lblError.Text = "Invalid Email or Password!.";
            //    }
            //}
            //else
            //{

            //}


        }


        private bool IsValid(string EmailAddress, string Password, out TUSER user)
        {
            user = null;
            EPSDBDataContext context =
                new EPSDBDataContext(ConfigurationManager.
                ConnectionStrings["EPSDBConnectionString"]
                .ConnectionString);

            var userdetails = context.TUSERs.SingleOrDefault
                (x => x.EmailAddress.ToLower() == EmailAddress);

            if (userdetails != null)
            {
                if (userdetails.Password == Password)
                {
                    user = userdetails;
                    return true;
                }
            }

            return false;
        }
    }
}