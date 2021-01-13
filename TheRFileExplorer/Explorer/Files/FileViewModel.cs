using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TheRFramework.Utilities;

namespace TheRFileExplorer.Explorer.Files
{
    public class FileViewModel : BaseViewModel
    {
        private ImageSource _icon;
        private string _filePath;
        private string _fileName;
        private string _dateModified;
        private FileType _fileType;
        private string _fileSizeBytes;

        public ImageSource Icon
        {
            get => _icon;
            set => RaisePropertyChanged(ref _icon, value);
        }

        public string FilePath
        {
            get => _filePath;
            set => RaisePropertyChanged(ref _filePath, value, UpdateFileName);
        }

        public string FileName
        {
            get => _fileName;
            set => RaisePropertyChanged(ref _fileName, value);
        }

        public string DateModified
        {
            get => _dateModified;
            set => RaisePropertyChanged(ref _dateModified, value);
        }

        public FileType FileType
        {
            get => _fileType;
            set => RaisePropertyChanged(ref _fileType, value);
        }

        public string FileSizeBytes
        {
            get => _fileSizeBytes;
            set => RaisePropertyChanged(ref _fileSizeBytes, value);
        }

        public FileViewModel()
        {

        }

        private void UpdateFileName()
        {
            FileName = Path.GetFileName(FilePath);
        }
    }
}
