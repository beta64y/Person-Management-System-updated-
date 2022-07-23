using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Users;

namespace Person_Management_System__updated_.Database.Models.Inbox
{
    internal class Messages
    {
        public User Addressee { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime Sent { get; set; }
        public Messages(User addressee, User sender, string text, DateTime sent)
        {
            Addressee = addressee;
            Sender = sender;
            Text = text;
            Sent = sent;
        }
    }
}
