using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace LibraryConsole_IE
{
    internal class ConsoleApp
    {   
        CommonLibrary function = new CommonLibrary();
        public void StartConsole(int currentID)
        {
            
            //LoginStatus log = new LoginStatus();
            //function.startup(); Console.WriteLine("Started");
            Console.WriteLine("Welcome to the library Console");
            Console.WriteLine("Type the corresponding key for what you would like to do from: ");
            Console.WriteLine("g - guest,  r- register, l - login, o - logout, pp - print profile, pr - print roles, pu - print users, or exit to end program");
            var input = Console.ReadLine();
            //CommonLibrary function = new CommonLibrary();
            //LoginStatus log = new LoginStatus();
            if(currentID == 0) { Console.WriteLine("Logged in as guest."); }


            switch (input.ToLower())
            {
                case "g":
                    restart(1, 0);
                    break;
                case "r":
                    //register
                    function.Register();
                    restart(1, currentID);
                    break;
                case "l":
                    //login
                    int returnID = function.Login();
                    if(function.adminCheck(returnID) == true)
                    {
                        Console.WriteLine("Enter admin Console (y/n)?");
                        string query = Console.ReadLine();
                        if(query.ToLower() == "y")
                        {
                            AdminConsole(returnID);
                        }
                    }
                    else { restart(1, returnID); }

                    break;
                case "o":
                    //logout 
                    restart(1, currentID);
                    Console.WriteLine("Logged out.");
                    break;
                case "pp":
                    // print profile
                    function.PrintProfile(currentID);
                    restart(1, currentID);
                    break;
                case "pr":
                    //print roles
                    function.PrintRoles();
                    restart(1, currentID);
                    break;
                case "pu":
                    //print users
                    function.PrintUsers();
                    restart(1, currentID);
                    break;
                case "exit":
                    break;
                default:
                    Console.Error.WriteLine("Option does not exist, restarting");
                    restart(1, currentID);
                    break;
                }
        }

        public void restart(int i, int loginID)
        {
            if (i == 1)
            {
                StartConsole(loginID);
            }
        }
    
        public void AdminConsole(int id)
        {
            Console.WriteLine("Welcome to admin console, select an option");
            Console.WriteLine("Delete user - d, Add new admin - a, Update user - u, return to main menu - r");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "d":
                    //delete
                    function.DeleteProfile();
                    restart(1, id);
                    break;
                case "u":
                    //update
                    function.UpdateProfile();
                    restart(1, id);
                    break;
                case "a":
                    //new admin
                    function.RegisterAdmin();
                    restart(1, id);
                    break;
                case "r":
                    //return
                    restart(1, id);
                    break;
                default:
                    break;
            }
                
        }
    }
}
