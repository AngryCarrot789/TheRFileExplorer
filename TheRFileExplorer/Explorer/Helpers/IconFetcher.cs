using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using TheRFileExplorer.Explorer.Files;

namespace TheRFileExplorer.Explorer.Helpers
{
    public static class IconFetcher
    {
        private static Thread IconReceiverThread { get; set; }

        private static bool CanRun { get; set; }
        public static bool IsFetchingIcons { get; set; }

        private static List<FileViewModel> IncommingFetcherPool { get; set; }
        private static List<FileViewModel> FetcherPool { get; set; }

        public static void Initialise()
        {
            CanRun = true;
            IncommingFetcherPool = new List<FileViewModel>();
            FetcherPool = new List<FileViewModel>();
            IconReceiverThread = new Thread(ReceiveIcons);
            IconReceiverThread.Start();
        }

        private static void ReceiveIcons()
        {
            while (CanRun)
            {
                lock (FetcherPool)
                {
                    IsFetchingIcons = true;
                    foreach (FileViewModel file in FetcherPool)
                    {
                        if (IsFetchingIcons)
                        {
                            Icon icon = IconHelper.GetIconOfFile(file.FilePath, true, file.FileType == FileType.Directory ? true : false);
                            if (IsFetchingIcons)
                            {
                                ImageSource source = IconHelper.ToImageSource(icon);
                                source.Freeze();
                                if (IsFetchingIcons)
                                {
                                    Application.Current?.Dispatcher?.Invoke(() =>
                                    {
                                        file.Icon = source.Clone();
                                    });
                                }
                                else break;
                            }
                            else break;
                        }
                        else break;
                    }

                    FetcherPool.Clear();
                    IsFetchingIcons = false;
                }


                if (IncommingFetcherPool.Count > 0)
                {
                    lock (IncommingFetcherPool)
                    {
                        lock (FetcherPool)
                        {
                            foreach (FileViewModel file in IncommingFetcherPool)
                            {
                                FetcherPool.Add(file);
                            }
                            IncommingFetcherPool.Clear();
                        }
                    }
                }

                Thread.Sleep(1);
            }
        }

        public static void FetchIcon(FileViewModel file)
        {
            if (IsFetchingIcons)
            {
                lock (IncommingFetcherPool)
                {
                    IncommingFetcherPool.Add(file);
                }
            }
            else
            {
                lock (FetcherPool)
                {
                    FetcherPool.Add(file);
                }
            }
        }

        public static void StopFetching()
        {
            IsFetchingIcons = false;
            FetcherPool.Clear();
            IncommingFetcherPool.Clear();
        }


        public static void ForceStop()
        {
            CanRun = false;
        }
    }
}
