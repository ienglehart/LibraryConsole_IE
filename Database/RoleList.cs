using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RoleList
    {
        public List<RoleDTO> Role { set; get; } = new List<RoleDTO>()
        {
            new RoleDTO()
            {
                RoleName = "Admin",
                RoleId = 1,
            },
            new RoleDTO()
            {
                RoleName = "Librarian",
                RoleId = 2,
            },
            new RoleDTO()
            {
                RoleName = "User",
                RoleId = 3,
            },
            new RoleDTO()
            {
                RoleName = "Guest",
                RoleId = 4,
            },

        };
    }
}
