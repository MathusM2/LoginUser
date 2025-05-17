using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginUserWPF.Models;

namespace LoginUserWPF.ViewModel
{
    public class RegisterAppViewModel : INotifyPropertyChanged
    {
        private UserModel _registerUser;

        public InputFieldModel<string> UserName { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserEmail { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserGender { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserAge { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserPassword { get; set; } = new InputFieldModel<string>();

        public RegisterAppViewModel()
        {
            _registerUser = new UserModel();
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
