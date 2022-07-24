using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Inbox;

namespace Person_Management_System__updated_.Database.Models.Users
{
    internal class User
    {
        public int Id { get; private set; }
        private  static int IdCounter = 1;
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Report> reportinbox { get; set; } = new List<Report>();
      



        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = IdCounter++;
            CreationTime = DateTime.Now;
        }
        public User(string firstName, string lastName, string email, string password,int id, DateTime datetime)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = id;
            CreationTime = datetime;
        }
        public virtual string GetInfo()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
