using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LoginUserWPF.Data;
using LoginUserWPF.Models;
using LoginUserWPF.Services;

namespace LoginUserWPF.ViewModel
{
    public class RegisterAppViewModel : INotifyPropertyChanged
    {
        private UserModel _registerUser;
        public ICommand TryRegisterCommand { get; }
        public ObservableCollection<string> GenderOptions { get; } = new()
        {
            "Select", "Men", "Women", "Undefined","I prefer not to say", "Other"
        };

        public InputFieldModel<string> UserName { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserEmail { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserGender { get; set; } = new InputFieldModel<string>() {Value = "Select"};
        public InputFieldModel<string> UserAge { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserPassword { get; set; } = new InputFieldModel<string>();

        public RegisterAppViewModel()
        {
            TryRegisterCommand = new RelayCommand<string>(TryRegister);
            _registerUser = new UserModel();

        }
        private void TryRegister(string pass)
        {
            MessageBox.Show(pass);
            if(ValidateInputs(UserName.Value, UserEmail.Value, UserGender.Value, UserAge.Value, pass) == false)
            {
                MessageBox.Show("Please correct the errors", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Register(pass);
            }
        }
        private bool ValidateInputs(string userName, string userEmail, string userGender, string userAge, string pass)
        {
            (bool hasErrorName, string? MessageName) = ValidateUserInput.ValidateName(userName);
            UserName.hasError = !hasErrorName;
            UserName.Message = MessageName ?? string.Empty;
            (bool hasErrorEmail, string? MessageEmail) = ValidateUserInput.ValidateEmail(userEmail);
            UserEmail.hasError = !hasErrorEmail;
            UserEmail.Message = MessageEmail ?? string.Empty;
            (bool hasErrorAge, string? MessageAge) = ValidateUserInput.ValidateAge(userAge);
            UserAge.hasError = !hasErrorAge;
            UserAge.Message = MessageAge ?? string.Empty;
            (bool hasErrorGender, string? MessageGender) = ValidateUserInput.ValidateGender(userGender);
            UserGender.hasError = !hasErrorGender;
            UserGender.Message = MessageGender ?? string.Empty;

            if(!hasErrorName || !hasErrorEmail || !hasErrorAge || !hasErrorGender)
            {
                return false;
            }
            else
            {
                (bool isValidPassword, string MessagePass) = ValidateUserInput.ValidatePassword(pass);
                if(isValidPassword)
                {
                    MessageBox.Show("All inputs are valid", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else
                {
                    UserPassword.hasError = !isValidPassword;
                    UserPassword.Message = MessagePass ?? string.Empty;
                    return false;
                }
            }
        }
        private void Register(string pass)
        {
            _registerUser.UserName = UserName.Value;
            _registerUser.UserEmail = UserEmail.Value;
            _registerUser.UserGender = UserGender.Value;
            _registerUser.UserAge = UserAge.Value;

            MessageBox.Show("User registered successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
