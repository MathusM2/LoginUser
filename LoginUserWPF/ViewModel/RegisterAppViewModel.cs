using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.ViewModel
{
    public class RegisterAppViewModel
    {
        private LoginAppViewModel _viewModel;

        public RegisterAppViewModel()
        {
            _viewModel = new LoginAppViewModel();
        }

        public string UserName
        {
            get { return _viewModel.UserName; }
            set { _viewModel.UserName = value; }
        }
    }
}
