using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;

namespace Common
{
    public class CRUD
    {
        UserList uList = new UserList();
        DB dB = new DB();
        public void Create(int id, string name, int role_id, string uName, string pass)
        {
            dB.create(id, name, role_id, uName, pass);
            //uList.User.Add(new UserDTO() { ID = id, Name = name, Username = uName, Password = pass, role = role });
        }

        public UserDTO Read(int id)
        {
            UserDTO result = dB.readID(id);
            return result;
            /*
            List<UserDTO> item = uList.User;
            UserDTO result = item.Find(x => x.ID == id);
            return result;
            */
        }
        public UserDTO ReadUsername(string arg)
        {
            return dB.readUser(arg);

            /*
            List<UserDTO> item = uList.User;
            UserDTO result = item.Find(x => x.Username.Contains(arg));
            return result;
            */
        }
        public void ReadAll()
        {
            
            dB.readAll();

            //foreach (UserDTO item in uList.User)
            //{
            //    Console.WriteLine("User: {0}, Username: {1}, Role: {2}", item.Name, item.Username, item.role.RoleName);
            //}
        }
        public int ReadLength()
        {
            //out of use for right now 
            return uList.User.Count;
        }
        public void Update(string arg, string itemUpdating, string update)
        {
            dB.update(arg, itemUpdating, update);

            /*
            if(itemUpdating == "name")
            {
                
                foreach (UserDTO item2 in uList.User.Where(x => x.Username.Contains(arg)))
                {
                    item2.Name = update;
                }
               
            }else if(itemUpdating == "username")
            {
                foreach (UserDTO item2 in uList.User.Where(x => x.Username.Contains(arg)))
                {
                    item2.Username = update;
                }
            }else if(itemUpdating == "password")
            {
                //if()
                foreach (UserDTO item2 in uList.User.Where(x => x.Username.Contains(arg)))
                {
                    item2.Password = update;
                }
            }
            */
        }
        public void Delete(string arg)
        {
            dB.delete(arg);
            /*
            UserDTO result = uList.User.Find(x => x.Username.Contains(arg));

            uList.User.Remove(result);
            */
        }
    }
}
