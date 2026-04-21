using BLL.Admin;
using DataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManaghement.Admin
{
    public partial class UserCreate : System.Web.UI.Page
    {
        private readonly UserService _service = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    LoadUser(id);
                }
            }

        }

        private void LoadUser(int id)
        {
            var user = _service.GetUser(id);

            if (user != null)
            {
                hfUserId.Value = user.UserId.ToString();
                txtName.Text = user.FullName;
                txtEmail.Text = user.EmailId;
                txtPhone.Text = user.PhoneNo;
                txtAddress.Text = user.Address;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfUserId.Value))
            {
                // 🔹 CREATE
                var request = new UserRequest
                {
                    FullName = txtName.Text,
                    EmailId = txtEmail.Text,
                    PhoneNo = txtPhone.Text,
                    Address = txtAddress.Text,
                    Password = txtPassword.Text
                };

                var result = _service.CreateUser(request);

                lblMessage.Text = result.message;
                txtName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtPassword.Text = "";

            }
            else
            {
                // 🔹 UPDATE
                int id = Convert.ToInt32(hfUserId.Value);

                var request = new UpdateUserRequest
                {
                    FullName = txtName.Text,
                    PhoneNo = txtPhone.Text,
                    Address = txtAddress.Text
                };

                var result = _service.UpdateUser(id, request);

                lblMessage.Text = result.message;
            }
        }


    }
}