using BLL.Admin;
using DataModels.DTO;
using System;

namespace StudentManaghement.Admin
{
    public partial class StudentsList : System.Web.UI.Page
    {
        private StudentService _service = new StudentService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        private void LoadStudents()
        {
            var students = _service.GetAllStudents();

            gvStudents.DataSource = students;
            gvStudents.DataBind();
        }

        // 🔹 CREATE
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var request = new StudentRequest
            {
                FullName = txtName.Text,
                EmailId = txtEmail.Text,
                PhoneNo = txtPhone.Text,
                Address = txtAddress.Text,
                Password = txtPassword.Text,
                CreatedBy = 1 // temp
            };

            var result = _service.CreateStudent(request);

            if (result.success)
            {
                ClearForm();
                LoadStudents();
            }
        }

        // 🔹 UPDATE
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfStudentId.Value);

            var request = new UpdateUserRequest
            {
                FullName = txtName.Text,
                PhoneNo = txtPhone.Text,
                Address = txtAddress.Text,
                UpdatedBy = 1
            };

            var result = _service.UpdateStudent(id, request);

            if (result.success)
            {
                ClearForm();
                LoadStudents();
            }
        }

        // 🔹 GRID ACTIONS
        protected void gvStudents_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditRow")
            {
                var student = _service.GetStudent(id);

                if (student != null)
                {
                    hfStudentId.Value = student.StudentId.ToString();
                    txtName.Text = student.FullName;
                    txtEmail.Text = student.EmailId;
                    txtPhone.Text = student.PhoneNo;
                    txtAddress.Text = student.Address;
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                _service.DeleteStudent(id);
                LoadStudents();
            }
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            hfStudentId.Value = "";
        }
    }
}