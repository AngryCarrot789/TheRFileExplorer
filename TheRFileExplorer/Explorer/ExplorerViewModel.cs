using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheRFileExplorer.Explorer.Files;
using TheRFileExplorer.Explorer.Helpers;
using TheRFileExplorer.Explorer.Navigation;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Explorer
{
    public class ExplorerViewModel : BaseViewModel
    {
        public ObservableCollection<FileViewModel> Files { get; set; }

        public FileNavigationViewModel Navigator { get; set; }

        private bool HasFoundFiles { get; set; }
        private bool HasFoundDirectories { get; set; }

        public ExplorerViewModel()
        {
            Files = new ObservableCollection<FileViewModel>();

            Navigator = new FileNavigationViewModel();
            Navigator.Explorer = this;

            FileFetcher.Initialise();
            IconFetcher.Initialise();
            FileFetcher.DirectoryFetchedCallback = OnDirectoryFetched;
            FileFetcher.FileFetchedCallback = OnFileFetched;
            FileFetcher.DirectoriesFetchedCallback = FoundDirectories;
            FileFetcher.FilesFetchedCallback = FoundFiles;
        }

        private void FoundFiles()
        {
            HasFoundFiles = true;
            if (HasFoundDirectories)
            {
                Sort();
                HasFoundDirectories = false;
            }
        }

        private void FoundDirectories()
        {
            HasFoundDirectories = true;
            if (HasFoundFiles)
            {
                Sort();
                HasFoundFiles = false;
            }
        }

        public void Sort()
        {
            List<FileViewModel> files = new List<FileViewModel>(Files);
            files.GroupBy(x => x.FileType);
            Files.Clear();
            foreach(FileViewModel file in files)
            {
                Files.Add(file);
            }
        }

        public void NavigateToDirectory(string directoryPath)
        {
            FileFetcher.StopFetching();
            Files.Clear();
            FileFetcher.StartFetching(directoryPath);
        }

        public FileViewModel CreateFile(FileModel file)
        {
            FileViewModel fvm = new FileViewModel();
            fvm.DateModified = file.DateModified.ToString("T");
            fvm.FilePath = file.FilePath;
            fvm.FileSizeBytes = file.SizeBytes < int.MaxValue ? $"{file.SizeBytes} Bytes" : "";
            fvm.FileType = file.Type;
            return fvm;
        }

        private void OnDirectoryFetched(FileModel file)
        {
            Application.Current?.Dispatcher?.Invoke(() =>
            {
                FileViewModel fvm = CreateFile(file);
                IconFetcher.FetchIcon(fvm);
                Files.Add(fvm);
            });
        }

        private void OnFileFetched(FileModel file)
        {
            Application.Current?.Dispatcher?.Invoke(() =>
            {
                FileViewModel fvm = CreateFile(file);
                IconFetcher.FetchIcon(fvm);
                Files.Add(fvm);
            });
        }
    }
}
