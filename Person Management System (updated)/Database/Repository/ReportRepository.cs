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
        public static void AddReport(User sender, string reason, User target)
        {
            Report report = new Report(sender, reason, target);
            target.reportinbox.Add(report);
            foreach (User user in UserRepository.Users)
            {
                if (user is Admin && target != user)
                {
                    user.reportinbox.Add(report);
                }
            }
        }
    }
}
