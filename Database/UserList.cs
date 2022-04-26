using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class UserList
    {
        public List<UserDTO> User { set; get; } = new List<UserDTO>()
        {
            new UserDTO()
            {
                ID = 0,
                Name = "Guest User",
                Username = "Guest",
                Password = "9b8769a4a742959a2d0298c36fb70623f2dfacda8436237df08d8dfd5b37374c",
                role = 4
            },
            new UserDTO()
            {
                ID = 1,
                Name = "Ian Englehart",
                Username = "ienglehart",
                Password = "9b8769a4a742959a2d0298c36fb70623f2dfacda8436237df08d8dfd5b37374c",
                role = 1
            },
            new UserDTO()
            {
                ID = 2,
                Name = "Ray Smith",
                Username = "rsmith",
                Password = "9b8769a4a742959a2d0298c36fb70623f2dfacda8436237df08d8dfd5b37374c",
                role = 3
            }
        };
    }
}
