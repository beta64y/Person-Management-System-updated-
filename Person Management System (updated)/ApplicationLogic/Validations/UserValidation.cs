using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Person_Management_System__updated_.Database.Models;
using Person_Management_System__updated_.Database.Repository;

namespace Person_Management_System__updated_.ApplicationLogic.Validations
{
    internal class UserValidation
    {
        public static bool IsValidName(string Name)
        {
            Regex regex = new Regex(@"[A-Z][a-z]{2,29}");

            if (regex.IsMatch(Name))
            {
                return true;
            }         

            return false;
        }
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]{10,30}@gmail\.com$");

            if (regex.IsMatch(email) && !UserRepository.IsUserExistByEmail(email))
            {
                return true ;
            }
            return false;
        }
        public static bool IsValidPassword(string text)
        {
            bool upper = false, lower = false, digit = false;

            foreach (char character in text)
            {
                if (char.IsUpper(character)) { upper = true; }
                if (char.IsLower(character)) { lower = true; }
                if (char.IsDigit(character)) { digit = true; }
            }
            if (upper && lower && digit && text.Length >= 8)
            {
                return true;
            }
            return false;


        }
    }
}
