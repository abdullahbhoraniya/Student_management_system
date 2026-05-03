using BLL.Admin;
using DataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManaghement.Admin
{
    public partial class UserDeactivation : System.Web.UI.Page
    {

        UserService _repo;
        public UserDeactivation()
        {
            _repo = new UserService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }
        public void LoadUsers()
        {
            List<UserResponse> userResponse = _repo.GetUsersList();
            gvUsers.DataSource = userResponse;
            gvUsers.DataBind();
        }

        public void ShowMessage(string message, string color)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.FromName(color);
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                UserResponse userResponse = (UserResponse)e.Row.DataItem;

                if(userResponse.status.ToLower() == "inactive")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                   
                }

                //If phone number is null it will add 'N/A' instead of empty place

                if(userResponse == null)
                {
                    string phone = (string)userResponse.PhoneNo;
                }
                string mobile = DataBinder.Eval(e.Row.DataItem, "PhoneNo").ToString();

                

                if (string.IsNullOrEmpty(mobile))
                {
                    //e.Row.Cells[3].Text = "-";
                    Label lblPhone = (Label)e.Row.FindControl("lblPhoneNo");
                }


                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
                    if (ddlStatus != null)
                    {
                        ddlStatus.SelectedValue = userResponse.status;
                    }
                }

            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();

        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        public void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            
            DropDownList ddl = (DropDownList)gvUsers.Rows[e.RowIndex].FindControl("ddlStatus");
            TextBox txtEmail = (TextBox)gvUsers.Rows[e.RowIndex].FindControl("txtEmail_edt");
            string status = ddl.SelectedValue;

            gvUsers.EditIndex = -1;
            LoadUsers();

        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            var deleteuserResponse = _repo.DeleteUser(userId);
            if (deleteuserResponse.success)
            {
                ShowMessage("User deleted successfully", "Green");
            }
            else
            {
                ShowMessage("Failed to delete user", "Red");
            }
                LoadUsers();

        }

        protected void gvUsers_DataBound(object sender, EventArgs e)
        {

        }
    }

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

}