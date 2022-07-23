﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Management_System__updated_.Database.Models.Users
{
    internal class User
    {
        public int Id { get; private set; }
        protected int IdCounter { get; set; } = 1;
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public DateTime CreationTime { get; set; }

        
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Id = IdCounter++;
            CreationTime = DateTime.Now;
        }
        public virtual string GetInfo()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
