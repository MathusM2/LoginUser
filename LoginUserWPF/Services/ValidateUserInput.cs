using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoginUserWPF.Helper;

namespace LoginUserWPF.Services
{
    /// <summary>
    /// Validate the data entry, and returns the result validate
    /// </summary>
    /// <returns>Return a boolean and an error message</returns>
    public static class ValidateUserInput
    {
        public static (bool, string?) ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (false, "The field is required");
            }
            else
            if (name.Length > 100)
            {
                return (false, "The field only accepts 100 characters.");
            }
            else
            if (name.Any(char.IsDigit))
            {
                return (false, "The field only accepts letters");
            }
            else
            {
                return (true, null);
            }
        }

        /// <summary>
        /// Validate email data
        /// </summary>
        /// <param name="email"></param>
        public static (bool, string?) ValidateEmail(string email)
        {
            string emailPattern = (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            Regex emailRegex = new Regex(emailPattern);

            if (string.IsNullOrEmpty(email))
            {
                return (false, "The field is required");
            }
            else
            if (email.Length > 100)
            {
                return (false, "The field only accepts 100 characters");
            }
            else
            if (!emailRegex.IsMatch(email))
            {
                return (false, "Invalid format email!");
            }
            else
            {
                return (true, null);
            }
        }

        public static (bool, string?) ValidatePassword(string password)
        {
            string passwordPattern = (@"^(?=.*[A-Z])(?=.*/d)(?=.*[^a-zA-Z0-9])");
            if(string.IsNullOrEmpty(password))
            {
                return (false, "The field is required");
            }
            else
            if(password.Length < 5 || password.Length > 100)
            {
                return (false, "The password must be greater than 5 characters and less than 100 characters");
            }
            switch (PasswordStrengthEvaluator.Evaluate(password))
            {
                case 1:
                    return (false, "Your password is very weak");
                case 2:
                    return (true, "Your password is moderate");
                case 3:
                    return (true, "Your password is strength");
                case 4:
                    return (true, "Your password is very strength");
                default:
                    return (false, "Press a valid password");
            }
        }

        public static (bool, string?) ValidateAge(int age)
        {
            if(age < 0 || age.GetType() != typeof(int))
            {
                return (false, "Invalid age format");
            }
            else
            if(age >= 100)
            {
                return (false, "Please check your age input — that seems unusually high");
            }
            else if(age < 10)
            {
                return (false, "This age is not accepted, please press a valid age");
            }
            else
            {
                return (true, null);
            }
        }

        public static (bool, string?) ValidateGender(string gender)
        {
            var validGendersOptions = new[] { "Men", "Women", "I don't prefer to say", "Other" };

            if(string.IsNullOrEmpty(gender))
            {
                return (false, "The field is required");
            }
            else
            if (!validGendersOptions.Contains(gender) || gender.GetType() != typeof(string))
            {
                return (false, "Invalid gender selection/format");
            }
            else
            {
                return (true, null);
            }
        }
    }
}
