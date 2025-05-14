using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginUserWPF.Models;

namespace LoginUserWPF.ViewModel
{
    public class RegisterAppViewModel
    {
        private UserModel _registerUser;

        public InputFieldModel<string> UserName { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserEmail { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserGender { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserInput { get; set; } = new InputFieldModel<string>();
        public InputFieldModel<string> UserPassword { get; set; } = new InputFieldModel<string>();

        public RegisterAppViewModel()
        {
            _registerUser = new UserModel();
        }

    }
}
