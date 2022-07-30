using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Inbox;
using Person_Management_System__updated_.Database.Models.Users;

namespace Person_Management_System__updated_.Database.Repository
{
    internal class MessageRepository
    {
        private List<Message> messages = new List<Message>();
        public static void SentMessage(User Address, Message message)
        {
            Address.Inbox.Add(message);
        }
        public static void ResetInbox(User user)
        {
            user.Inbox.Clear();
        }
    }
}
