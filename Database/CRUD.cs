using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;
using System.Configuration;

namespace Database
{

    public class CRUD
    {
        static string GetConn(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        //using entity framework
        public void ReadAll()
        {
            try
            {
                using (var db = new UserDB())
                {
                    var query = from user in db.Users
                                join role in db.Roles on user.role_id equals role.role_id
                                select new
                                {
                                    name = user.name,
                                    username = user.username,
                                    role = role.role1

                                };

                    foreach (var item in query)
                    {
                        Console.WriteLine("User: " + item.name + " with username: " + item.username + " and role: " + item.role);
                    }
                }
            }
            catch (Exception ex)
            {
                exceptionLogging(ex);
            }
        }
        public UserDTO ReadById(int id)
        {
            try
            {

                using (var db = new UserDB())
                {
                    var query = from user in db.Users
                                join role in db.Roles on user.role_id equals role.role_id
                                where user.user_id == id
                                select new
                                {
                                    name = user.name,
                                    username = user.username,
                                    pass = user.password,
                                    role = role.role1,
                                    id = user.user_id
                                };
                    UserDTO data = new UserDTO();
                    //this was the only way i could find to interact with the query data?
                    //Probably a better way. Should still function since the ID is always unique
                    foreach (var item in query)
                    {
                        UserDTO result = new UserDTO()
                        {
                            ID = item.id,
                            role = item.role,
                            Username = item.username,
                            Password = item.pass,
                            Name = item.name
                        };
                        data = result;
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                exceptionLogging(ex);
                return null;
            }


        }
        public UserDTO ReadByUsername(string arg)
        {
            try 
            {
                using (var db = new UserDB())
                {
                    var query = from user in db.Users
                                join role in db.Roles on user.role_id equals role.role_id
                                where user.username == arg
                                select new
                                {
                                    name = user.name,
                                    username = user.username,
                                    pass = user.password,
                                    role = role.role1,
                                    id = user.user_id
                                };

                    UserDTO data = new UserDTO();
                    //this was the only way i could find to interact with the query data?
                    //Probably a better way. Should still function since the ID is always unique
                    foreach(var item in query)
                    {
                        UserDTO result = new UserDTO()
                        {
                            ID = item.id,
                            role = item.role,
                            Username = item.username,
                            Password = item.pass,
                            Name = item.name
                        };
                        data = result;
                    }
                    return data;
                }
            } 
            catch(Exception ex)
            { 
                exceptionLogging(ex);
                return null;
            }
            
        }
        public int HighID()
        {
            try
            {
                using (var db = new UserDB())
                {
                    int maxID = db.Users.Max(p => p.user_id);
                    return maxID;
                }
            }
            catch (Exception ex)
            {
                exceptionLogging(ex);
                return 0;
            }
        }
        //Using a normal database call
        public void Create(int id, string name, int role_ID, string uName, string pass)
        {
            try
            {
                SqlConnection con = new SqlConnection(GetConn("UserDB"));

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
            }catch(Exception ex)
            {
                exceptionLogging(ex);
            }

        }
        public void Update(string username, string updating, string changes)
        {
            try
            { 
                SqlConnection con = new SqlConnection(GetConn("UserDB"));

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
            catch(Exception ex)
            {
                exceptionLogging(ex);
            }
        }
        public void Delete(string user)
        {
            try
            {
                SqlConnection con = new SqlConnection(GetConn("UserDB"));

                SqlCommand cmd = new SqlCommand("deleteUser", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.Add(new SqlParameter("@user", user));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }catch(Exception ex)
            {
                exceptionLogging(ex);
            }
        }

        //log exceptions
        public void exceptionLogging(Exception ex)
        {
            SqlConnection con = new SqlConnection(GetConn("UserDB"));

            SqlCommand cmd = new SqlCommand("ExceptionLogger", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 60;

            cmd.Parameters.Add(new SqlParameter("@ExceptionMsg", ex.Message.ToString()));
            cmd.Parameters.Add(new SqlParameter("@ExceptionType", ex.GetType().Name.ToString()));
            cmd.Parameters.Add(new SqlParameter("@ExceptionSource", ex.StackTrace.ToString()));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
    }
}
