using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Users;

namespace Person_Management_System__updated_.Database.Models.Inbox
{
    internal class Report : Messages
    {
        public User Target { get; set; }
        private int SerisesCounter { get; set; } = 1;
        public int Series { get; set; }
        public Report(User sender, string text, User target)
            : base(sender, text)
        {
            Target = target;
            Series = SerisesCounter++;
        }
    }
}
