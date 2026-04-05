using DataModels.Entity;
using System;
using System.Data.SqlClient;

namespace DAL.Student
{
    public class StudentRepository
    {
        public Students GetStudent(int studentId)
        {
            Students student = null;

            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Students WHERE sid = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", studentId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = MapStudent(reader);
                        }
                    }
                }
            }

            return student;
        }

        public int InsertStudent(Students student)
        {
            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO Students 
                                (full_name, email_id, phone_no, address, password, created_by, created_date)
                                VALUES 
                                (@full_name, @email_id, @phone_no, @address, @password, @created_by, @created_date);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@full_name", student.full_name);
                    cmd.Parameters.AddWithValue("@email_id", student.email_id);
                    cmd.Parameters.AddWithValue("@phone_no", student.phone_no);
                    cmd.Parameters.AddWithValue("@address", student.address);
                    cmd.Parameters.AddWithValue("@password", student.password);
                    cmd.Parameters.AddWithValue("@created_by", (object)student.created_by ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Now);

                    conn.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdateStudent(Students student)
        {
            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE Students SET
                                full_name = @full_name,
                                email_id = @email_id,
                                phone_no = @phone_no,
                                address = @address,
                                updated_by = @updated_by,
                                update_date = @update_date
                                WHERE sid = @sid";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@full_name", student.full_name);
                    cmd.Parameters.AddWithValue("@email_id", student.email_id);
                    cmd.Parameters.AddWithValue("@phone_no", student.phone_no);
                    cmd.Parameters.AddWithValue("@address", student.address);
                    cmd.Parameters.AddWithValue("@updated_by", (object)student.updated_by ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@update_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@sid", student.sid);

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public Students Login(string email, string password)
        {
            Students student = null;

            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM Students 
                                 WHERE email_id = @Email AND password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = MapStudent(reader);
                        }
                    }
                }
            }

            return student;
        }

        // 🔥 Common mapper (don’t repeat yourself)
        private Students MapStudent(SqlDataReader reader)
        {
            return new Students
            {
                sid = Convert.ToInt32(reader["sid"]),
                full_name = reader["full_name"]?.ToString(),
                email_id = reader["email_id"]?.ToString(),
                phone_no = reader["phone_no"]?.ToString(),
                address = reader["address"]?.ToString(),
                password = reader["password"]?.ToString(),
                created_by = reader["created_by"] != DBNull.Value ? Convert.ToInt32(reader["created_by"]) : (int?)null,
                updated_by = reader["updated_by"] != DBNull.Value ? Convert.ToInt32(reader["updated_by"]) : (int?)null,
                created_date = reader["created_date"] != DBNull.Value ? Convert.ToDateTime(reader["created_date"]) : (DateTime?)null,
                update_date = reader["update_date"] != DBNull.Value ? Convert.ToDateTime(reader["update_date"]) : (DateTime?)null
            };
        }
    }
}