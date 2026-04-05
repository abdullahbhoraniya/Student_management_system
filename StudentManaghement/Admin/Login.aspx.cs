
using System;
using BLL.Admin;
using DataModels.DTO;
using DataModels.Entity;

namespace StudentManaghement.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UserService _userService = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Email and Password are required";
                return;
            }

            var user = _userService.Login(email, password);

            if (user != null)
            {
                // ✅ Store session
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.FullName;

                // ✅ Redirect
                Response.Redirect("~/AdminDashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid email or password";
            }
        }
    }
}