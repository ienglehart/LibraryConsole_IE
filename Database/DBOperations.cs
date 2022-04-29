using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DBOperations
    {
        public void readAll()
        {
            using (var db = new UserDB())
            {
                var query = from user in db.Users
                            join role in db.Roles on user.role_id equals role.role_id
                            select new { 
                                name = user.name,
                                username = user.username,
                                role = role.role1 
                            
                            };

                foreach(var item in query)
                {
                    Console.WriteLine("User: " + item.name + " with username: " + item.username + " and role: " + item.role);
                }
            }
        }

        public void readById(int id)
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
                            role = role.role1

                        };
            }
                
            
        }

        public void readByUsername(string arg)
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
                                role = role.role1

                            };
            }
        }
    }
}
