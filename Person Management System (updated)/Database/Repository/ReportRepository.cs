using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Users;
using Person_Management_System__updated_.Database.Models.Inbox;
using Person_Management_System__updated_.Database.Repository;

namespace Person_Management_System__updated_.Database.Repository
{
    internal class ReportRepository
    {
        private static List<Report> Reports { get; set; } = new List<Report>()
        {
            

        };
        public static void AddReport(User sender, string reason, User target)
        {
            Report report = new Report(sender, reason, target);
            Reports.Add(report);
            target.reportinbox.Add(report);
            foreach (User user in UserRepository.GetUsers())
            {
                if (user is Admin && target != user)
                {
                    user.reportinbox.Add(report);
                }
            }
        }
    }
}
