using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoginUserWPF.Helper;
using LoginUserWPF.Helper.Behaviors;
using LoginUserWPF.Services;
using LoginUserWPF.View;
using LoginUserWPF.ViewModel;
using MaterialDesignThemes.Wpf;

namespace LoginUserWPF
{
    /// <summary>
    /// Interaction logic for MainWindowzz.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginAppViewModel _viewModel;
        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginAppViewModel();
            this.DataContext = _viewModel;
            _viewModel.OpenRegisterWindowRequested += OpenRegisterWindow;
        }
        private void OpenRegisterWindow()
        {
            var registerWindow = new RegisterView();
            registerWindow.Owner = this;
            registerWindow.ShowDialog();
        }

        private void LoginConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.TryLogin();
        }
    }
}