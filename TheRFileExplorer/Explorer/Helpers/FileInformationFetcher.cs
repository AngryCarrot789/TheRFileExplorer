using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRFileExplorer.Explorer.Files;

namespace TheRFileExplorer.Explorer.Helpers
{
    public static class FileInformationFetcher
    {
        public static int GetSize(FileViewModel file)
        {
            string fileSize = file.FileSizeBytes;
            if (fileSize.Length > 3)
            {
                string size = fileSize.Substring(0, fileSize.Length - 3);
                return int.Parse(size);
            }
            else
            {
                return int.MaxValue;
            }
        }
    }
}
