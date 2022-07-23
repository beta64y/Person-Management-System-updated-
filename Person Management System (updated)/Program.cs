using System;
using Person_Management_System__updated_.ApplicationLogic;

namespace Person_Management_System__updated_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi , You Can Use /help Command for Get Information about Commads !");
            while (true)
            {
                
                Console.Write("\nEnter command : ");
                string command = Console.ReadLine();

                if (command == "/register")
                {
                    Authentication.Register();
                }
                else if (command == "/login")
                {
                    Authentication.Login();                   
                }
                else if (command == "/logout")
                {
                    Authentication.Logout();
                }
                else if (command == "/panel")
                {
                    Authentication.OpenPanel();
                }
                else if (command == "/accountinfo")
                {
                    Authentication.AccountInfo();
                }
                else if (command == "/help")
                {
                    Console.WriteLine("/exit - close program");
                    Console.WriteLine("/register - allows you to register");
                    Console.WriteLine("/login - allows you to log in");
                    Console.WriteLine("/logout - allows you to log out");
                    Console.WriteLine("/accountinfo - show active account info");
                    
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("May the Force be with you");
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
