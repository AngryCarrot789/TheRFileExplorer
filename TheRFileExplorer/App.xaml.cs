using System.Windows;
using TheRFileExplorer.Windows;
using TheRFileExplorer.Windows.Main;

namespace TheRFileExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WindowManager.Initialise(this, e.Args);

            WindowManager.Main.Show();
        }
    }
}
