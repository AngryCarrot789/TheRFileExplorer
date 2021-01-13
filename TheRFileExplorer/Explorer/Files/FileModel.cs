using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRFileExplorer.Explorer.Files
{
    public struct FileModel
    {
        public string FilePath { get; set; }
        public DateTime DateModified { get; set; }
        public FileType Type { get; set; }
        public long SizeBytes { get; set; }

        public FileModel(string path, DateTime time, FileType type, long size)
        {
            FilePath = path;
            DateModified = time;
            Type = type;
            SizeBytes = size;
        }
    }
}
