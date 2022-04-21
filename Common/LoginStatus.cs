using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LoginStatus
    {
        int _id { get; set; }
        bool _log { get; set; }
        public LoginStatus()
        {
            _id = -1;
            _log = false;
        }
        public void logTrue()
        {
            _log = true;
        }
        public void logFalse()
        {
            _log = false;
        }
        public void setID(int id)
        {
            _id = id;
        }
        public int returnID()
        {
            if(_id != -1)
            {
                return _id;
            }
            else
            {
                Console.WriteLine("Not logged in!");
                return -1;
            }
        }
    }
}
