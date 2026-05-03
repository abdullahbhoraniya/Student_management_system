using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManaghement.Admin
{
    public partial class admin_mst : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 🚨 Session check (IMPORTANT)

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