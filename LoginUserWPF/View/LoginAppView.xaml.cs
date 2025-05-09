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
using LoginUserWPF.View;
using LoginUserWPF.ViewModel;

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
        }

        private void LoginConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string result = _viewModel.TryLogin(LoginInputPassword.Password);
            MessageBox.Show(result);
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show();
            
        }
    }
}