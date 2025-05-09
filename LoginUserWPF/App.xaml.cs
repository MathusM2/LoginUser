using System.Configuration;
using System.Data;
using System.Windows;
using LoginUserWPF.Data;

namespace LoginUserWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DatabaseInitializer.Initialize();

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }

}
