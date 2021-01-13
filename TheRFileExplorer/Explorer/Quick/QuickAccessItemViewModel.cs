using System;
using System.Windows.Media;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Explorer.Quick
{
    public class QuickAccessItemViewModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public ImageSource Icon { get; set; }

        public Command NavigateCommand { get; }

        public Action<string> NavigateCallback { get; set; }

        public QuickAccessItemViewModel()
        {
            NavigateCommand = new Command(Navigate);
        }

        public void Navigate()
        {
            NavigateCallback?.Invoke(FilePath);
        }
    }
}
