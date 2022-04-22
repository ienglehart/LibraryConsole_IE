using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Database;

namespace Common
{
    public class CommonLibrary
    {
        CRUD c = new CRUD();

        public void PrintUsers()
        {
            c.ReadAll();
            Console.WriteLine();
        }
        public void PrintRoles()
        {
            Console.WriteLine("Current Roles include: Guest, Admin, Librarian, and Patron");
        }
        public int Login()
        {
            Console.WriteLine("Enter Username.");
            string usernameInput = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string passRaw = Console.ReadLine();
            string pass = Hash(passRaw);

            UserDTO read = c.ReadUsername(usernameInput);
            
            if (read.Username == usernameInput && read.Password == pass)
            {
                Console.Write("Logged in as: "+usernameInput);
            }
            return read.ID;
        }
        public void Register()
        {
            Console.WriteLine("Enter a name to register");
            string name = Console.ReadLine();

            int accept = 0;
            string role;
            RoleDTO role2 = new RoleDTO() { RoleName = "Guest", RoleId = 4 };
            do
            {
                //remove and use enums slacker
                Console.WriteLine("What role is this user?");
                Console.WriteLine("Guest, Librarian, or Patron");
                role = Console.ReadLine();
                if(role.ToLower() == "guest")
                {
                    accept = 1;
                    role2 = new RoleDTO() { RoleName = "Guest", RoleId = 4 };
                }
                else if(role.ToLower() == "librarian")
                {
                    accept = 1;
                    role2 = new RoleDTO() { RoleName = "Librarian", RoleId = 2 };
                }
                else if(role.ToLower() == "patron")
                {
                    accept = 1;
                    role2 = new RoleDTO() { RoleName = "Patron", RoleId = 3 };
                }
                else { Console.WriteLine("Not a valid role."); }
            } while (accept == 0);

            Console.WriteLine("What will the username be?");
            string username = Console.ReadLine();

            Console.WriteLine("Create a password.");
            string passInput = Console.ReadLine();
            string pass = Hash(passInput);

            int id = GenerateID();

            c.Create(id, name, role2, username, pass);
        }
        public void RegisterAdmin()
        {
            Console.WriteLine("Enter a name to register");
            string name = Console.ReadLine();

            RoleDTO role = new RoleDTO() { RoleId = 1 };
            
            Console.WriteLine("What will the username be?");
            string username = Console.ReadLine();

            Console.WriteLine("Create a password.");
            string passInput = Console.ReadLine();
            string pass = Hash(passInput);

            int id = GenerateID();

            c.Create(id, name, role, username, pass);
        }
        public void PrintProfile(int id)
        {
            if(id != -1)
            {
            UserDTO item = c.Read(id);
            Console.WriteLine("ID: {0} Name: {1} Role: {2} Username: {3}", item.ID, item.Name, item.role, item.Username); 
            }
            else { Console.WriteLine("Not logged in."); }
        }
        public void UpdateProfile()
        {
            Console.WriteLine("What is the username of the user you will be updating.");
            string user = Console.ReadLine();
            Console.WriteLine("What aspect are you changing (Name, Username, or Role)");
            string aspect = Console.ReadLine().ToLower();
            Console.WriteLine("What are you changing it to?"); 
            string change = Console.ReadLine();

            c.Update(user, aspect, change);
        }

        public void DeleteProfile()
        {
            Console.WriteLine("What is the username of the profile you wish to delete?");
            string user = Console.ReadLine();
            Console.WriteLine("This will not be recoverable, are you sure? (y/n)");
            if(Console.ReadLine() == "y")
            {
                c.Delete(user);
            }  
        }



        public string Hash(string a)
        {
            StringBuilder result = new StringBuilder();
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(a));

                //StringBuilder result = new StringBuilder();
                foreach (byte b in bytes)
                {
                    result.Append(b.ToString());
                }
            }
            return result.ToString();
        }
        
        public int GenerateID()
        {
            CRUD crud = new CRUD();
            return crud.ReadLength();
        } 
    
        public bool adminCheck(int id)
        {
            CRUD c = new CRUD();
            UserDTO result = c.Read(id);
            if(result.role.RoleName == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    
        


    }
}
