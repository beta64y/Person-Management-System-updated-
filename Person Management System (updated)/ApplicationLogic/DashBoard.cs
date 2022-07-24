using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Management_System__updated_.ApplicationLogic
{
    internal class DashBoard
    {public static void UserPanel()
        {
            Console.WriteLine("Hi , You are currently using the panel ,You Can Use /support Command for Get Information about panel !");
            while (true)
            {

                Console.Write("\nEnter panel command : ");
                string command = Console.ReadLine();

                if (command == "/inbox")
                {
                    
                }
                else if (command == "/update-user")
                {
                    Authentication.Update();
                }
                else if (command == "/report-user")
                {
                    
                }
                else if (command == "/support")
                {
                    Console.WriteLine("/close - close panel");
                    Console.WriteLine("/update-user - This command allows you to update your account");



                }
                else if (command == "/close")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found!");
                }
            }
        }
        public static void AdminPanel()
        {
            Console.WriteLine("Hi dear Admin, You are currently using the panel ,You Can Use /support Command for Get Information about panel !");
            while (true)
            {

                Console.Write("\nEnter panel command : ");
                string command = Console.ReadLine();

                if (command == "/inbox")
                {

                }
                else if (command == "/remove-user")
                {
                    Authentication.BanUser(); 
                }
                else if (command == "/update-admin")
                {
                    Authentication.UpdateforAdmin();
                }
                else if (command == "/report-info")
                {

                }              
                else if (command == "/support")
                {
                    Console.WriteLine("/close - close panel");
                    Console.WriteLine("/update-user - this command allows you to update your account");
                    Console.WriteLine("/update-admin - this command is updating the selected admin's account");

                }
                else if (command == "/close")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found!");
                }
            }
        }
        
    }
}
