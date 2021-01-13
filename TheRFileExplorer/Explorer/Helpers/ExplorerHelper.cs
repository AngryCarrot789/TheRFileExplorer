using System.IO;

namespace TheRFileExplorer.Explorer.Helpers
{
    public static class ExplorerHelper
    {
        public static bool IsFile(this string path)
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }

        public static bool IsDirectory(this string path)
        {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }

        public static bool IsDrive(this string path)
        {
            return !string.IsNullOrEmpty(path) && path.Length < 3;
        }

        public static string GetDirectoryName(string fullpath)
        {
            if (string.IsNullOrEmpty(fullpath))
                return string.Empty;

            int lastIndex = fullpath.Replace('/', '\\').LastIndexOf('\\');
            string final = lastIndex <= 0 ? fullpath : fullpath.Substring(lastIndex + 1);
            return final;
        }
    }
}
