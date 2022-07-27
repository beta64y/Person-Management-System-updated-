using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Repository;
using Person_Management_System__updated_.Database.Models.Users;
using Person_Management_System__updated_.Services;

namespace Person_Management_System__updated_.ApplicationLogic
{
    internal class Authentication
    {
       protected static User Account { get; set; }
       protected static bool IsAuthorized { get; set; } = false;

        public static User GetAccount()
        {
            return Account;
        }
        
         public static void OpenPanel()
         {
            
            if (Account is Admin && IsAuthorized)
            {
                DashBoard.AdminPanel();
            }
            else if(IsAuthorized)
            {
                DashBoard.UserPanel();
            }
            else
            {
                Console.WriteLine("You must login first to open panel");
            }
            
            
         }
        

        public static void Register()
        {
            string firstName = AuthendicationServices.GetFirstName();
            string lastName = AuthendicationServices.GetLastName();
            string email = AuthendicationServices.GetEmail();
            string password = AuthendicationServices.GetPassword();

            {
                User user = UserRepository.Add(firstName, lastName, email, password);
                Console.WriteLine($"User added to system, his/her details are : {user.GetInfo()}");
            }
        }


        public static void Login()
        {
            if (!IsAuthorized)
            {
                Console.Write("Please enter user's email : ");
                string email = Console.ReadLine();

                Console.Write("Please enter user's password : ");
                string password = Console.ReadLine();

                if (UserRepository.IsUserExistByEmailAndPassword(email, password))
                {
                    User user = UserRepository.GetUserByEmailAndPassword(email, password);
                    if (user is Admin)
                    {
                        Console.WriteLine($"Admin successfully authenticated : {user.GetInfo()}");
                    }
                    else
                    {                   
                        Console.WriteLine($"User successfully authenticated : {user.GetInfo()}");                     
                    }
                    Account = user;
                    IsAuthorized = true;
                    OpenPanel();
                }
                else
                {
                    Console.WriteLine("Email or Password is not valid");
                }

            }
            else
            {
                Console.WriteLine("You are already logged in . Please , log out first.");
            }
        }

        
        public static void Logout()
        {
            if(IsAuthorized)
            {
                Account = null;
                IsAuthorized=false;
                Console.WriteLine("Logged out");
            }
            else
            {
                Console.WriteLine("You must login first to log out.");
            }

        }
        
        
        public static void AccountInfo()
        {
            if (IsAuthorized)
            {
                Console.WriteLine($"{Account.FirstName} {Account.LastName} {Account.Email} {Account.CreationTime}");
            }
            else
            {
                Console.WriteLine("You must login first.");
            }
        }
        
        
        public static void Help()
        {
            Console.WriteLine("/exit - close program");
            Console.WriteLine("/register - allows you to register");
            Console.WriteLine("/login - allows you to log in");
            Console.WriteLine("/logout - allows you to log out");
            Console.WriteLine("/accountinfo - show active account info");
            Console.WriteLine("/panel - open panel");
        }
        
        




       

    }
    
}
