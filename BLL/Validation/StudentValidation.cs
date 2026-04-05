using DataModels.Entity;

namespace BLL.Validation
{
    public class StudentValidator
    {
        public bool ValidateStudent(Students student, out string message)
        {
            message = "";

            if (student == null)
            {
                message = "Student is null";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.full_name))
            {
                message = "Full name required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.email_id))
            {
                message = "Email required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.password))
            {
                message = "Password required";
                return false;
            }

            return true;
        }
    }
}