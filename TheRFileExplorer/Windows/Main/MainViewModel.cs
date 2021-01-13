using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRFileExplorer.Explorer;
using TheRFileExplorer.Explorer.Quick;
using TheRFileExplorer.Windows.Help;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Windows.Main
{
    public class MainViewModel : BaseViewModel
    {
        public HelpViewModel Help { get; set; }
        public ThemesViewModel Themes { get; set; }

        public ExplorerViewModel Explorer { get; set; }
        public QuickAccessViewModel QuickAccess { get; set; }

        public MainViewModel()
        {
            Help = new HelpViewModel();
            Themes = new ThemesViewModel();

            Explorer = new ExplorerViewModel();
            QuickAccess = new QuickAccessViewModel();
            QuickAccess.NavigateCallback = Explorer.NavigateToDirectory;
        }
    }
}
