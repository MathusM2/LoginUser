using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LoginUserWPF.Controls;
using LoginUserWPF.ViewModel;

namespace LoginUserWPF.View
{
    /// <summary>
    /// Lógica interna para RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly RegisterAppViewModel _viewModel;
        public RegisterView()
        {
            InitializeComponent();
            _viewModel = new RegisterAppViewModel();
            this.DataContext = _viewModel;
            
        }

        private void RegisterButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.TryRegisterCommand.CanExecute(RegisterInputPassword.Password))
            {
                _viewModel.TryRegisterCommand.Execute(RegisterInputPassword.Password);
            }
        }
    }
}
