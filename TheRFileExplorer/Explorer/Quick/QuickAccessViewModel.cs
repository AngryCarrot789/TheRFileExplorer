using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TheRFileExplorer.Explorer.Helpers;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Explorer.Quick
{
    public class QuickAccessViewModel : BaseViewModel
    {
        public ObservableCollection<QuickAccessItemViewModel> QuickAccessItems { get; set; }

        public Action<string> NavigateCallback { get; set; } 

        public QuickAccessViewModel()
        {
            QuickAccessItems = new ObservableCollection<QuickAccessItemViewModel>();

            QuickAccessItemViewModel desktop = new QuickAccessItemViewModel()
            {
                FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            desktop.FileName = Path.GetDirectoryName(desktop.FilePath);
            desktop.Icon = new BitmapImage(new Uri(@"Resources\QuickAccess\desktopIcon.ico", UriKind.Relative));
            desktop.NavigateCallback = Navigate;

            QuickAccessItems.Add(desktop);
        }

        private void Navigate(string to)
        {
            NavigateCallback?.Invoke(to);
        }
    }
}
