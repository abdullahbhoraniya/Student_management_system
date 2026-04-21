using BLL.Validation;
using DAL.Admin;
using DAL.Student;
using DataModels.DTO;
using DataModels.Entity;
using System;
using System.Collections.Generic;

namespace BLL.Admin
{
    public class StudentService
    {
        private readonly StudentRepository _repo;
        private readonly StudentValidator _validator;

        public StudentService()
        {
            _repo = new StudentRepository();
            _validator = new StudentValidator();
        }
        public List<StudentResponse> GetAllStudents()
        {
            var students = _repo.GetAllStudents();

            List<StudentResponse> list = new List<StudentResponse>();

            foreach (var s in students)
            {
                list.Add(new StudentResponse
                {
                    StudentId = s.sid,
                    FullName = s.full_name,
                    EmailId = s.email_id,
                    PhoneNo = s.phone_no,
                    Address = s.address,
                    CreatedBy = s.created_by,
                    UpdatedBy = s.updated_by,
                    CreatedDate = s.created_date,
                    UpdateDate = s.update_date
                });
            }

            return list;
        }
        // 🔹 CREATE STUDENT
        public (bool success, string message, int studentId) CreateStudent(StudentRequest request)
        {
            if (request == null)
                return (false, "Request is null", 0);

            var student = new Students
            {
                full_name = request.FullName,
                email_id = request.EmailId,
                phone_no = request.PhoneNo,
                address = request.Address,
                password = request.Password,
                created_by = request.CreatedBy,
                created_date = DateTime.Now
            };

            if (!_validator.ValidateStudent(student, out string validationMessage))
                return (false, validationMessage, 0);

            int id = _repo.InsertStudent(student);

            return (true, "Student created successfully", id);
        }

        // 🔹 GET STUDENT
        public StudentResponse GetStudent(int studentId)
        {
            if (studentId <= 0)
                return null;

            var student = _repo.GetStudent(studentId);

            if (student == null)
                return null;

            return MapToResponse(student);
        }

        public (bool success,string message) DeleteStudent(int studentId)
        {
            if(studentId <= 0)
            {
                return (false, "Id cannot be zero or negative");
            }
            bool deleted = _repo.DeleteStudent(studentId);
            if (deleted)
            {
                return (true, "Student Deleted successfully");
            }
            else
            {
                return (false, "Student not found woth this id ");
            }
        }

        // 🔹 UPDATE STUDENT
        public (bool success, string message) UpdateStudent(int studentId, UpdateUserRequest request)
        {
            if (studentId <= 0)
                return (false, "Invalid student ID");

            if (request == null)
                return (false, "Request is null");

            var existingStudent = _repo.GetStudent(studentId);

            if (existingStudent == null)
                return (false, "Student not found");

            // ✅ Partial update
            if (!string.IsNullOrWhiteSpace(request.FullName))
                existingStudent.full_name = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.PhoneNo))
                existingStudent.phone_no = request.PhoneNo;

            if (!string.IsNullOrWhiteSpace(request.Address))
                existingStudent.address = request.Address;

            existingStudent.updated_by = request.UpdatedBy;
            existingStudent.update_date = DateTime.Now;

            bool updated = _repo.UpdateStudent(existingStudent);

            return updated
                ? (true, "Student updated successfully")
                : (false, "Update failed");
        }
        
        // 🔹 LOGIN
        public StudentResponse Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            var student = _repo.Login(email, password);

            if (student == null)
                return null;

            return MapToResponse(student);
        }

        // 🔹 PRIVATE MAPPING
        private StudentResponse MapToResponse(Students student)
        {
            return new StudentResponse
            {
                StudentId = student.sid,
                FullName = student.full_name,
                EmailId = student.email_id,
                PhoneNo = student.phone_no,
                Address = student.address,
                CreatedBy = student.created_by,
                UpdatedBy = student.updated_by,
                CreatedDate = student.created_date,
                UpdateDate = student.update_date
            };
        }
    }
}