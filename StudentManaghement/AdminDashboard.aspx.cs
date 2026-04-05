using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManaghement
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            // 🚨 Session check (IMPORTANT)
            if (Session["UserId"] == null)
            {
                Response.Redirect("Admin/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblUserName.Text = Session["UserName"]?.ToString();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Admin/Login.aspx");
        }
    }
}
