using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Explorer.Navigation
{
    public class FileNavigationViewModel : BaseViewModel
    {
        private string _directoryPath;
        public string DirectoryPath
        {
            get => _directoryPath;
            set => RaisePropertyChanged(ref _directoryPath, value);
        }

        public Command NavigateBackCommand { get; }
        public Command NavigateForwardCommand { get; }
        public Command RefreshDirectoryCommand { get; }
        public Command NavigateCommand { get; }

        public ExplorerViewModel Explorer { get; set; }

        public FileNavigationViewModel()
        {
            NavigateBackCommand = new Command(NavigateBack);
            NavigateForwardCommand = new Command(NavigateForward);
            RefreshDirectoryCommand = new Command(RefreshDirectory);
            NavigateCommand = new Command(Navigate);

            DirectoryPath = "";
        }

        private void Navigate()
        {
            Explorer.NavigateToDirectory(DirectoryPath);
        }

        public void NavigateBack()
        {

        }

        public void NavigateForward()
        {

        }

        public void RefreshDirectory()
        {

        }
    }
}
