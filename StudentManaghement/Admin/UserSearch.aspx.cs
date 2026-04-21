using BLL.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManaghement.Admin
{
    public partial class UserSearch : System.Web.UI.Page
    {

        private readonly UserService _service = new UserService();

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            gvUsers.DataSource = _service.GetUsersList(search);
            gvUsers.DataBind();
        }


        private void LoadUsers()
        {
            // ⚠️ You need to create this method in service
            gvUsers.DataSource = _service.GetUsersList();
            gvUsers.DataBind();
        }
    }
}