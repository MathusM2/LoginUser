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
        private LoginUserModel _loginUser;

        public LoginAppViewModel()
        {
            _loginUser = new LoginUserModel();
        }

        public string Username
        {
            get { return _loginUser.Username; }
            set { _loginUser.Username = value; }
        }

        public string Useremail
        {
            get { return _loginUser.Useremail; }
            set { _loginUser.Useremail = value; }
        }

        public string TryLogin(string password)
        {
            if (string.IsNullOrEmpty(_loginUser.Username) || string.IsNullOrEmpty(_loginUser.Useremail) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Fill in all fields!");
            }
            else if (password.Length < 5)
            {
                MessageBox.Show("The password must contain more than 5 characters!");
            }
            else
            {
                string result = $"Hello Mr/Ms {_loginUser.Username}, your email is: \n{_loginUser.Useremail}";
                return result;
            }
            return "Invalid acess! Try again";

        }
    }
}
