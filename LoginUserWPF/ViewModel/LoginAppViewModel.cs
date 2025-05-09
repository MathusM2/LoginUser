using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LoginUserWPF.Models;

namespace LoginUserWPF.ViewModel
{
    public class LoginAppViewModel
    {
        private UserModel _loginUser;

        public LoginAppViewModel()
        {
            _loginUser = new UserModel();
        }

        public string UserName
        {
            get { return _loginUser.UserName; }
            set { _loginUser.UserName = value; }
        }

        public string UserEmail
        {
            get { return _loginUser.UserEmail; }
            set { _loginUser.UserEmail = value; }
        }

        public string TryLogin(string password)
        {
            if (string.IsNullOrEmpty(_loginUser.UserName) || string.IsNullOrEmpty(_loginUser.UserEmail) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fill in all fields!");
            }
            else if (password.Length < 5)
            {
                MessageBox.Show("The password must contain more than 5 characters!");
            }
            else
            {
                string result = $"Hello Mr/Ms {_loginUser.UserName}, your email is: \n{_loginUser.UserEmail}";
                return result;
            }
            return "Invalid acess! Try again";

        }
    }
}
