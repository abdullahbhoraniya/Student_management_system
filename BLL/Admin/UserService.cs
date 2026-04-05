using BLL.Validation;
using DAL.Admin;
using DataModels.DTO;
using DataModels.Entity;
using System;
using System.Collections.Generic;

namespace BLL.Admin
{
    public class UserService
    {
        private readonly UserRepositery _repo;
        private readonly UserValidator _validator;

        public UserService()
        {
            _repo = new UserRepositery();
            _validator = new UserValidator();
        }

        // 🔹 CREATE USER
        public (bool success, string message, int userId) CreateUser(UserRequest request)
        {
            if (request == null)
                return (false, "Request is null", 0);

            // Map DTO → Entity
            var user = new Users
            {
                full_name = request.FullName,
                email_id = request.EmailId,
                phone_no = request.PhoneNo,
                address = request.Address,
                password = request.Password,
                created_by = request.CreatedBy,
                created_date = DateTime.Now
            };

            // Validate
            if (!_validator.ValidateUser(user, out string validationMessage))
                return (false, validationMessage, 0);

            int id = _repo.InsertUser(user);

            return (true, "User created successfully", id);
        }

        // 🔹 GET USER BY ID
        public UserResponse GetUser(int userId)
        {
            if (userId <= 0)
                return null;

            var user = _repo.GetUsers(userId);

            if (user == null)
                return null;

            return MapToResponse(user);
        }

        // 🔹 UPDATE USER
        public (bool success, string message) UpdateUser(int userId, UpdateUserRequest request)
        {
            if (userId <= 0)
                return (false, "Invalid user ID");

            if (request == null)
                return (false, "Request is null");

            var existingUser = _repo.GetUsers(userId);

            if (existingUser == null)
                return (false, "User not found");

            // Partial update (safe approach)
            if (!string.IsNullOrWhiteSpace(request.FullName))
                existingUser.full_name = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.PhoneNo))
                existingUser.phone_no = request.PhoneNo;

            if (!string.IsNullOrWhiteSpace(request.Address))
                existingUser.address = request.Address;

            existingUser.updated_by = request.UpdatedBy;
            existingUser.update_date = DateTime.Now;

            bool updated = _repo.UpdateUser(existingUser);

            return updated
                ? (true, "User updated successfully")
                : (false, "Update failed");
        }

        // 🔹 LOGIN
        public UserResponse Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = _repo.Login(email, password);

            if (user == null)
                return null;

            return MapToResponse(user);
        }

        public List<UserResponse> GetUsersList(string search = "")
        {
            // Step 1: Call DAL
            List<Users> users = _repo.GetUsers(search);

            // Step 2: Map to DTO
            List<UserResponse> responseList = new List<UserResponse>();

            foreach (var user in users)
            {
                responseList.Add(MapToResponse(user));
            }
            
            return responseList;
        }


        // 🔹 PRIVATE MAPPING METHOD
        private UserResponse MapToResponse(Users user)
        {
            UserResponse userRes = new UserResponse();

            userRes.UserId = user.stf_id;
            userRes.FullName = user.full_name;
            userRes.EmailId = user.email_id;
            userRes.PhoneNo = user.phone_no;
            userRes.Address = user.address;
            userRes.CreatedBy = user.created_by;
            userRes.UpdatedBy = user.updated_by;
            userRes.CreatedDate = user.created_date;
            userRes.UpdateDate = user.update_date;


            return userRes;
        }
    }
}