using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRFileExplorer.Explorer.Files;

namespace TheRFileExplorer.Explorer.Helpers
{
    public static class FileHelper
    {
        public static string GetFileSize(long size)
        {
            return size.ToString() + " Bytes";
        }

        public static FileViewModel CreateViewModel(FileModel file)
        {
            return new FileViewModel()
            {
                FilePath = file.FilePath,
                FileName = Path.GetFileName(file.FilePath),
                DateModified = file.DateModified.ToString("G"),
                FileType = file.Type,
                FileSizeBytes = GetFileSize(file.SizeBytes)
            };
        }

        public static bool OpenFile(string path)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path);
            Process p = new Process() { StartInfo = psi };
            return p.Start();
        }
    }
}
