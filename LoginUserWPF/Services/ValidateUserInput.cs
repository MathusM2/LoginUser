using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoginUserWPF.Helper;
using LoginUserWPF.Models;

namespace LoginUserWPF.Services
{
    /// <summary>
    /// Validate the data entry, and returns the result validate
    /// </summary>
    /// <returns>Return a boolean and an error message</returns>
    public static class ValidateUserInput
    {
        /// <summary>
        /// Validate name data
        /// </summary>
        /// <param name="name"></param>
        public static (bool, string?) ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (false, "Press your name");
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
                return (true, "");
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
                return (false, "Press your email");
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

        public static (bool, string) ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return (false, "Press the password");
            }
            else
            if (password.Length < 5 || password.Length > 100)
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

        public static (bool, string?) ValidateAge(string age)
        {
            var ageValid = int.TryParse(age, out int ageParsed);
            if (!ageValid)
            {
                return (false, "Invalid age format");
            }
            else
            if(ageParsed >= 100)
            {
                return (false, "Please check your age input — that seems unusually high");
            }
            else if(ageParsed < 10)
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
            if(gender == "Select")
            {
                return (false, "Select a gender");
            }
            else
            if(string.IsNullOrEmpty(gender))
            {
                return (false, "Invalid selection");
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

        public static (bool, string?) ValidateUserModel(UserModel userModel, string pass)
        {
            var (isValidInputs, MessageInput) = ValidateUserModelInputs(userModel);
            if (!isValidInputs)
            {
                return (false, MessageInput);
            }
            else
            {
                var (isValidPassword, MessagePass) = ValidateUserModelPassword(pass);
                if (isValidPassword)
                {
                    return (true, string.Empty);
                }
                else
                {
                    return (false, MessagePass);
                }
            }
        }

        private static (bool, string?) ValidateUserModelInputs(UserModel userModel)
        {
            var (isValidName, _) = ValidateName(userModel.UserName);
            var (isValidEmail, _) = ValidateEmail(userModel.UserEmail);
            var (isValidGender, _) = ValidateGender(userModel.UserGender);
            var (isValidAge, _) = ValidateAge(userModel.UserAge);

            if(isValidName && isValidEmail && isValidGender && isValidAge)
            {
                return (true, string.Empty);
            }
            else
            {
                return (false, "Invalid fields content, try again!");
            }
        }

        private static (bool, string?) ValidateUserModelPassword(string pass)
        {
            var (isValidPassword, Message) = ValidatePassword(pass);

            return isValidPassword ? (true, string.Empty) : (false, Message);
        }
    }
}
