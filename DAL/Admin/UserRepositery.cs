using DataModels.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin
{
    public class UserRepositery
    {


        public Users GetUsers(int UserId)
        {
            Users user = null;

            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE stf_id = @UserId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Users
                            {
                                stf_id = Convert.ToInt32(reader["stf_id"]),
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
            }

            return user;
        }


        public int InsertUser(Users user)
        {
            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"INSERT INTO Users 
                        (full_name, email_id, phone_no, address, password, created_by, created_date)
                        VALUES 
                        (@full_name, @email_id, @phone_no, @address, @password, @created_by, @created_date);
                        SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@full_name", user.full_name);
                    cmd.Parameters.AddWithValue("@email_id", user.email_id);
                    cmd.Parameters.AddWithValue("@phone_no", user.phone_no);
                    cmd.Parameters.AddWithValue("@address", user.address);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@created_by", (object)user.created_by ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Now);

                    conn.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool UpdateUser(Users user)
        {
            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"UPDATE Users SET
                        full_name = @full_name,
                        email_id = @email_id,
                        phone_no = @phone_no,
                        address = @address,
                        updated_by = @updated_by,
                        update_date = @update_date
                        WHERE stf_id = @stf_id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@full_name", user.full_name);
                    cmd.Parameters.AddWithValue("@email_id", user.email_id);
                    cmd.Parameters.AddWithValue("@phone_no", user.phone_no);
                    cmd.Parameters.AddWithValue("@address", user.address);
                    cmd.Parameters.AddWithValue("@updated_by", (object)user.updated_by ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@update_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@stf_id", user.stf_id);

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



        public Users Login(string email, string password)
        {
            Users user = null;

            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM Users 
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
                            user = new Users
                            {
                                stf_id = Convert.ToInt32(reader["stf_id"]),
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
            }

            return user;
        }


        public List<Users> GetUsers(string search = "")
        {
            List<Users> list = new List<Users>();

            DBConnection db = new DBConnection();

            using (SqlConnection conn = db.GetConnection())
            {
                string query = @"SELECT * FROM Users
                         WHERE (@search IS NULL OR @search = '' 
                         OR full_name LIKE @search 
                         OR email_id LIKE @search)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (string.IsNullOrWhiteSpace(search))
                        cmd.Parameters.AddWithValue("@search", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Users user = new Users();

                            user.stf_id = Convert.ToInt32(reader["stf_id"]);
                            user.full_name = reader["full_name"]?.ToString();
                            user.email_id = reader["email_id"]?.ToString();
                            user.phone_no = reader["phone_no"]?.ToString();
                            user.address = reader["address"]?.ToString();
                            user.password = reader["password"]?.ToString();
                            user.created_by = reader["created_by"] != DBNull.Value ? Convert.ToInt32(reader["created_by"]) : (int?)null;
                            user.updated_by = reader["updated_by"] != DBNull.Value ? Convert.ToInt32(reader["updated_by"]) : (int?)null;
                            user.created_date = reader["created_date"] != DBNull.Value ? Convert.ToDateTime(reader["created_date"]) : (DateTime?)null;
                            user.update_date = reader["update_date"] != DBNull.Value ? Convert.ToDateTime(reader["update_date"]) : (DateTime?)null;


                            list.Add(user);


                        }
                    }
                }
            }

            return list;
        }

    }
}
