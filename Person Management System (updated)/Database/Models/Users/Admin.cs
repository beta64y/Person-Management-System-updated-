﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Management_System__updated_.Database.Models.Users
{
    internal class Admin : User
    {
        public Admin(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password)
        {
        
        }
        public override string GetInfo()
        {
            return $"{FirstName} {LastName} {Email}";
        } 
    }
}