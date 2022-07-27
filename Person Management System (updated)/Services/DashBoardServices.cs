using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.ApplicationLogic;
using Person_Management_System__updated_.Database.Models.Inbox;
using Person_Management_System__updated_.Database.Models.Users;
using Person_Management_System__updated_.Database.Repository;

namespace Person_Management_System__updated_.Services
{
    internal class DashBoardServices
    {
        public static void ShowReports()
        {
            
            for (int i = 0; i < Authentication.GetAccount().reportinbox.Count; i++)
            {
                Report report = Authentication.GetAccount().reportinbox[i];
                Console.WriteLine($"{i + 1}. (report ID : {report.Id}) User ({report.Sender.Email}) report {report.Target.Email} Date : {report.Sent}\n{report.Text}");
            }
        }
        public static void ShowAllReports()
        {

            for (int i = 0; i < ReportRepository.GetReports().Count; i++)
            {
                Report report = ReportRepository.GetReports()[i];
                Console.WriteLine($"{i + 1}. (report ID : {report.Id}) User ({report.Sender.Email}) report {report.Target.Email} Date : {report.Sent}\n{report.Text}");
            }
        }
        public static void ReportUser()
        {
            Console.Write("Please enter target's email : ");
            string email = Console.ReadLine();
            Console.Write("Please enter reason of report : ");
            string reason = Console.ReadLine();
            if (email != Authentication.GetAccount().Email && ValidationServices.IsLengthBetween(reason, 10, 50) && UserRepository.IsUserExistByEmail(email))
            {
                User target = UserRepository.GetUserByEmail(email);
                ReportRepository.AddReport(Authentication.GetAccount(), reason, target);
                Console.WriteLine("User Reported");
            }
            else
            {
                Console.WriteLine("Rules : \n1. A User cannot report their own account \n2. The email entered must be valid \n3. The reason's length entered must be higher than 10 and less than 30 ");
            }
        }
        public static void BanUser()
        {
            if (Authentication.GetAccount() is Admin)
            {
                Console.Write("Please enter user's email : ");
                string email = Console.ReadLine();

                if (UserRepository.IsUserExistByEmail(email) && !(UserRepository.GetUserByEmail(email) is Admin))
                {
                    User user = UserRepository.GetUserByEmail(email);
                    Console.WriteLine($"{user.FirstName} {user.LastName} Permanently Banned");
                    UserRepository.RemoveUser(user);

                }
            }
        }
        public static void Update()
        {
            Console.Write("Please enter your password : ");
            string password = Console.ReadLine();
            if (Authentication.GetAccount().Password == password)
            {
                User user = UserRepository.GetUserByEmailAndPassword(Authentication.GetAccount().Email, password);
                Console.Write("(New) ");
                string New_FirstName = AuthendicationServices.GetFirstName();

                Console.Write("(New) ");
                string New_LastName = AuthendicationServices.GetLastName();
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
            if (Authentication.GetAccount().Email != email && UserRepository.IsUserExistByEmail(email) && UserRepository.GetUserByEmail(email) is Admin)
            {
                User user = UserRepository.GetUserByEmail(email);
                Console.Write("(New) ");
                string New_FirstName = AuthendicationServices.GetFirstName();

                Console.Write("(New) ");
                string New_LastName = AuthendicationServices.GetLastName();
                UserRepository.Update(user, New_FirstName, New_LastName);
                Console.WriteLine("Account Updated");

            }
            else
            {
                Console.WriteLine("Rules : \n1. An Admin cannot update their own account \n2. The email entered must be valid \n3. The email entered must be Admin ");
            }
        }
        public static void ShowUsers()
        {
            if (Authentication.GetAccount() is Admin)
            {
                foreach (User user in UserRepository.GetUsers())
                {
                    Console.WriteLine($"Name : \"{user.FirstName} {user.LastName}\" \nEmail : {user.Email} | Password : {user.Password} | ID : {user.Id} | Register Date : {user.CreationTime.ToString()}");

                }
            }
            else { Console.WriteLine("Only admin can use this command"); }

        }
        public static void ShowAdmins()
        {
            foreach (User user in UserRepository.GetUsers())
            {
                if (user is Admin)
                {
                    Console.WriteLine($"Name : \"{user.FirstName} {user.LastName}\" \nEmail : {user.Email} | Password : {user.Password} | ID : {user.Id} | Register Date : {user.CreationTime.ToString()}");
                }
            }


        }
        public static void AddAdmin()
        {
            Console.Write("Please enter user's email : ");
            string email = Console.ReadLine();
            if (Authentication.GetAccount().Email != email && UserRepository.IsUserExistByEmail(email) && !(UserRepository.GetUserByEmail(email) is Admin))
            {
                UserRepository.AddAdmin(UserRepository.GetUserByEmail(email));
            }
            else
            {
                Console.WriteLine("Rules : \n1. An Admin cannot Make admin their own account \n2. The email entered must be valid \n3. The email entered must be User ");
            }
        }
    }
}
