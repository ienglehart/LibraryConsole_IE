using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Database
{
    public class DB
    {       

        public void readAll()
        {
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            SqlConnection con = new SqlConnection(_connectionstring);
            //string _connectionstring = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;

            SqlCommand cmd = new SqlCommand("readAllUsers", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;
            
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // iterate through results, printing each to console
                while (rdr.Read())
                {
                    Console.WriteLine("users: {0} {1}", rdr["name"], rdr["username"]);
                }
            }
            con.Close();
            con.Dispose();
        }
        public UserDTO readID(int id)
        {
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            SqlConnection con = new SqlConnection(_connectionstring);
            //string _connectionstring = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;

            int newId;
            string name;
            string username;
            string password;
            int roleId;

            SqlCommand cmd = new SqlCommand("readById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add(new SqlParameter("@user_id", id));
            

            con.Open();
            cmd.ExecuteNonQuery();
            newId = Convert.ToInt32(cmd.Parameters["user_id"].Value);
            name = Convert.ToString(cmd.Parameters["name"].Value);
            username= Convert.ToString(cmd.Parameters["username"].Value);
            password = Convert.ToString(cmd.Parameters["password"].Value);
            roleId = Convert.ToInt32(cmd.Parameters["role_id"]);
            con.Close();
            con.Dispose();

            return new UserDTO() { ID = newId, Name = name, Username = username, Password = password, role = roleId };
        }
        public UserDTO readUser(string user)
        {

            string queryString =
                "SELECT * FROM dbo.Users WHERE Users.username = "+user+";";
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                        reader[0], reader[1]));
                    }
                }
            }
            return new UserDTO()
            {
                ID = 0,
                Name = "Guest User",
                Username = "Guest",
                Password = "9b8769a4a742959a2d0298c36fb70623f2dfacda8436237df08d8dfd5b37374c",
                role = 4
            };

            /*
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            SqlConnection con = new SqlConnection(_connectionstring);
            //string _connectionstring = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;
            
            int newId;
            string name;
            string username;
            string password;
            int roleId;

            SqlCommand cmd = new SqlCommand("readByUsername", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add(new SqlParameter("@username", user));

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                
                newId = Convert.ToInt32(rdr["user_id"]);
                name = rdr["name"].ToString();
                username = rdr["username"].ToString();
                password = rdr["password"].ToString();
                roleId = Convert.ToInt32(rdr["role_id"]);
                
            }
            con.Close();
            con.Dispose();

            return new UserDTO() { ID = newId, Name = name, Username = username, Password = password, role = roleId };
            */
        }

        public void create(int id, string name, int role_ID, string uName, string pass)
        {
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            SqlConnection con = new SqlConnection(_connectionstring);
            //string _connectionstring = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;

            
            SqlCommand cmd = new SqlCommand("CreateUser", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;
            
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@name", name));
            cmd.Parameters.Add(new SqlParameter("@username", uName));
            cmd.Parameters.Add(new SqlParameter("@password", pass));
            cmd.Parameters.Add(new SqlParameter("@role_id", role_ID));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();

        }

        public void update(string username, string updating, string changes)
        {
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            SqlConnection con = new SqlConnection(_connectionstring);
            //string _connectionstring = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;


            SqlCommand cmd = new SqlCommand("editUser", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@updated", updating));
            cmd.Parameters.Add(new SqlParameter("@changes", changes));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        public void delete(string user)
        {
            string _connectionstring = @"Server = DESKTOP-B60MBM1; Database = LibraryConsole; Trusted_Connection = True";
            SqlConnection con = new SqlConnection(_connectionstring);
            //string _connectionstring = ConfigurationManager.ConnectionStrings["UserDB"].ConnectionString;


            SqlCommand cmd = new SqlCommand("deleteUser", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add(new SqlParameter("@user", user));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
    }
}
