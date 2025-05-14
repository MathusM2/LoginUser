using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LoginUserWPF.Helper;
using LoginUserWPF.Infraestructure.LoginUserWPF.Helper;
using LoginUserWPF.Models;
using LoginUserWPF.Services;

namespace LoginUserWPF.ViewModel
{
    public class LoginAppViewModel : INotifyPropertyChanged
    {
        private UserModel _loginUser;
        public InputFieldModel<string> UserName { get; set; } = new InputFieldModel<string>();

        public InputFieldModel<string> UserEmail { get; set; } = new InputFieldModel<string>();

        public InputFieldModel<string> UserPassword { get; set; } = new InputFieldModel<string>();

        public LoginAppViewModel()
        {
            _loginUser = new UserModel();
        }

        public string TryLogin(string password)
        {
            return "Foda";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
