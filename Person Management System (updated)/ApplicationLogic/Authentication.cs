using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Repository;
using Person_Management_System__updated_.Database.Models.Users;
using Person_Management_System__updated_.Database.Models.Inbox;
using Person_Management_System__updated_.ApplicationLogic.Validations;
using Person_Management_System__updated_.ApplicationLogic;

namespace Person_Management_System__updated_.ApplicationLogic
{
    internal class Authentication
    {
       protected static User Account { get; set; }
       protected static bool IsAccountActive { get; set; } = false;
        
        
        public static void Help()
        {
            Console.WriteLine("/exit - close program");
            Console.WriteLine("/register - allows you to register");
            Console.WriteLine("/login - allows you to log in");
            Console.WriteLine("/logout - allows you to log out");
            Console.WriteLine("/accountinfo - show active account info");
            Console.WriteLine("/panel - open panel");
        }


        public static void Register()
        {
            string firstName = GetFirstName();
            string lastName = GetLastName();
            string email = GetEmail();
            string password = GetPassword();

            {
                User user = UserRepository.AddUser(firstName, lastName, email, password);
                Console.WriteLine($"User added to system, his/her details are : {user.GetInfo()}");
            }
        }



        public static void Login()
        {
            if (!IsAccountActive)
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
                    IsAccountActive = true;
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


        public static void ShowReports()
        {
            foreach (Report report in Account.reportinbox)
            {
                Console.WriteLine($"{report.Series}. User ({report.Sender.Email}) report {report.Target.Email} Date : {report.Sent}\n{report.Text}");
            }
        }
        

        public static void ReportUser()
        {
            Console.Write("Please enter target's email : ");
            string email = Console.ReadLine();
            Console.Write("Please enter reason of report : ");
            string reason = Console.ReadLine();
            if(email != Account.Email && Validation.IsLengthBetween(reason,10,30) && UserRepository.IsUserExistByEmail(email))
            {
                User target = UserRepository.GetUserByEmail(email);
                UserRepository.AddReport(Account, reason, target);
            }
            else
            {
                Console.WriteLine("Rules : \n1. A User cannot report their own account \n2. The email entered must be valid \n3. The reason's length entered must be higher than 10 and less than 30 ");
            }
        }

        public static void BanUser()
        {
            if(Account is Admin)
            {
                Console.Write("Please enter user's email : ");
                string email = Console.ReadLine();

                Console.Write("Please enter user's password : ");
                string password = Console.ReadLine();

                if (UserRepository.IsUserExistByEmailAndPassword(email, password))
                {
                    User user = UserRepository.GetUserByEmailAndPassword(email, password);
                    Console.WriteLine($"{user.FirstName} {user.LastName} Permanently Banned");
                    UserRepository.RemoveUser(user);
                    
                }
            }
        }

        public static void Logout()
        {
            if(IsAccountActive)
            {
                Account = null;
                IsAccountActive=false;
                Console.WriteLine("Logged out");
            }
            else
            {
                Console.WriteLine("You must login first to log out.");
            }

        }


        public static void AccountInfo()
        {
            if (IsAccountActive)
            {
                Console.WriteLine($"{Account.FirstName} {Account.LastName} {Account.Email} {Account.CreationTime}");
            }
            else
            {
                Console.WriteLine("You must login first.");
            }
        }


        public static void Update()
        {
            Console.Write("Please enter your email : ");
            string email = Console.ReadLine();

            Console.Write("Please enter your password : ");
            string password = Console.ReadLine();
            if (Account.Email == email && Account.Password == password)
            {
                User user = UserRepository.GetUserByEmailAndPassword(email, password);
                Console.Write("(New) ");
                string New_FirstName = GetFirstName();

                Console.Write("(New) ");
                string New_LastName = GetLastName();
                UserRepository.Update(user, New_FirstName, New_LastName);
                Console.WriteLine("Account Updated");

            }
            else
            {
                Console.WriteLine("Email or Password is not True");
            }

        }


        public static void UpdateforAdmin()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();
            if (Account.Email != email && UserRepository.IsUserExistByEmail(email) && UserRepository.GetUserByEmail(email) is Admin)
            {
                User user = UserRepository.GetUserByEmail(email);
                Console.Write("(New) ");
                string New_FirstName = GetFirstName();

                Console.Write("(New) ");
                string New_LastName = GetLastName();
                UserRepository.Update(user, New_FirstName, New_LastName);
                Console.WriteLine("Account Updated");

            }
            else
            {
                Console.WriteLine("Rules : \n1. An Admin cannot update their own account \n2. The email entered must be valid \n3. The email entered must be Admin ");
            }
        }
        


         public static void OpenPanel()
         {
            
            if (Account is Admin && IsAccountActive)
            {
                DashBoard.AdminPanel();
            }
            else if(IsAccountActive)
            {
                DashBoard.UserPanel();
            }
            else
            {
                Console.WriteLine("You must login first to open panel");
            }
            
            
         }

        
        
        
        public static string GetFirstName()
        {
            
            bool name_wrongChecker = false;
            string name = "";

            while (!UserValidation.IsValidName(name))
            {
                if (name_wrongChecker)
                {
                    Console.WriteLine($"The FirstName you entered is incorrect, make sure the FirstName contains only letters,\nthe first letter is capitalized, and the length is greater than 3 and less than 30.");
                }
                Console.WriteLine($"Enter FirstName :");
                name = Console.ReadLine();
                name_wrongChecker = true;
            }
            return name;
        }
        public static string GetLastName()
        {

            bool name_wrongChecker = false;
            string name = "";

            while (!UserValidation.IsValidName(name))
            {
                if (name_wrongChecker)
                {
                    Console.WriteLine($"The LastName you entered is incorrect, make sure the LastName contains only letters,\nthe first letter is capitalized, and the length is greater than 3 and less than 30.");
                }
                Console.WriteLine($"Enter LastName :");
                name = Console.ReadLine();
                name_wrongChecker = true;
            }
            return name;
        }
        public static string GetEmail()
        {
            bool email_wrongChecker = false;
            string email = "";

            while (!UserValidation.IsValidEmail(email))
            {
                if (email_wrongChecker)
                {
                    Console.WriteLine("The email you entered is incorrect, Receipent - can only be composed of letters and \nnumbers, the total length can be min 10 max 30, Separator - there must be an @ in \nbetween Domain - can only end with gamil.com.\n\"E-mail must be unique\"");
                }
                Console.WriteLine("Enter Email :");
                email = Console.ReadLine();
                email_wrongChecker = true;
            }
            return email;
        }
        public static string GetPassword()
        {
            bool password_wrongChecker = false;
            bool re_password_wrongChecker = false;
            string password = "";
            string re_password = "";

            while (!UserValidation.IsValidPassword(password))
            {
                if (password_wrongChecker)
                {
                    Console.WriteLine("The password you entered is incorrect, Password - Must contain at least one uppercase \nletter, one lowercase letter and a number, and length cannot be less than 8");
                }
                Console.WriteLine("Enter Password:");
                password = Console.ReadLine();
                password_wrongChecker = true;
            }


            while (!(password == re_password))
            {
                if (re_password_wrongChecker)
                {
                    Console.WriteLine("The password you re-entered is incorrect,Re-entered Password should be the same as the password ");
                }
                Console.WriteLine("Re-Enter Password :");
                re_password = Console.ReadLine();
                re_password_wrongChecker = true;
            }
            return password;
        }

    }
    
}
