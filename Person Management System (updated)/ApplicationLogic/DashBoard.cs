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
                else if (command == "/chat")
                {
                    
                }
                else if (command == "/support")
                {
                    Console.WriteLine("/close - close panel");
                    

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
                else if (command == "/block-user")
                {

                }
                else if (command == "/update-info")
                {

                }
                else if (command == "/report-info")
                {

                }
                else if (command == "/chat")
                {

                }
                else if (command == "/support")
                {
                    Console.WriteLine("/close - close panel");


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
