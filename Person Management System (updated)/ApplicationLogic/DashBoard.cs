using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Services;

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

                if (command == "/reports")
                {
                    DashBoardServices.ShowReports();
                }
                else if (command == "/update-user")
                {
                    DashBoardServices.Update();
                }
                else if (command == "/report-user")
                {
                    DashBoardServices.ReportUser();
                }
                else if(command == "/show-admin")
                {
                    DashBoardServices.ShowAdmins();
                }
                else if (command == "/support")
                {
                    Authentication.Support();
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

                if (command == "/reports")
                {
                    DashBoardServices.ShowReports();
                }
                if (command == "/show-all-reports")
                {
                    DashBoardServices.ShowAllReports();
                }
                else if (command == "/remove-user")
                {
                    DashBoardServices.BanUser(); 
                }
                else if (command == "/update-admin")
                {
                    DashBoardServices.UpdateforAdmin();
                }
                else if (command == "/make-admin")
                {
                    DashBoardServices.AddAdmin();
                }
                else if (command == "/show-users")
                {
                    DashBoardServices.ShowUsers();
                }
                else if (command == "/support")
                {
                    Authentication.Support();
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
