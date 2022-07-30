using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Users;

namespace Person_Management_System__updated_.Database.Models.Inbox
{
    internal class Message
    {
        private static int IdCounter = 1;
        public int Id { get; set; }
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime Sent { get; set; }
        public Message(User sender, string text)
        {
            Sender = sender;
            Text = text;
            Sent = DateTime.Now;
            Id = IdCounter++;
        }
    }
}
