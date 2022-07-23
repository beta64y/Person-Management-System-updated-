﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person_Management_System__updated_.Database.Models.Users;

namespace Person_Management_System__updated_.Database.Repository
{
    internal class UserRepository
    {
        private static List<User> Users { get; set; } = new List<User>()
        {
            new Admin("Yahya", "Camalzade", "YahyaCamalzade@gmail.com", "Yahya123"),
            new Admin("Yahya", "Camalzade", "YahyaCamalzade2@gmail.com", "Yahya123")

        };
        public static User AddUser(string firstName, string lastName, string email, string password)
        {
            User user = new User(firstName, lastName, email, password);
            Users.Add(user);
            return user;
        }
        public static void RemoveUser(User user)
        {
           Users.Remove(user);                
        }
        public static void Update(User user, string firstName, string lastName)
        {
            user.FirstName = firstName;
            user.LastName = lastName;           
        }
        public static bool IsUserExistByEmailAndPassword(string email ,string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }

            }
            return false;
        }
        public static bool IsUserExistByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return true;
                }

            }
            return false;
        }
        public static User GetUserByEmailAndPassword(string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }

            return null;
        }
        public static User GetUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }

            return null;
        }

    }
}
