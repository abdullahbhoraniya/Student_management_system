using DataModels.Entity;

namespace BLL.Validation
{
    public class UserValidator
    {
        public bool ValidateUser(Users user, out string message)
        {
            message = "";

            if (user == null)
            {
                message = "User object is null";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.full_name))
            {
                message = "Full name is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.email_id))
            {
                message = "Email is required";
                return false;
            }

            if (!user.email_id.Contains("@"))
            {
                message = "Invalid email format";
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.password))
            {
                message = "Password is required";
                return false;
            }

            return true;
        }
    }
}