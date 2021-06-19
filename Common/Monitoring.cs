using System.IO;

namespace Common
{
    class Monitoring
    {
        public FileSystemWatcher Watcher { get; set; }
        public Writer WriterObj { get; set; }

        private static object obj = new object();

        private const string monitoringPath = @"C:\";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Monitoring(string fileName)
        {
            //インスタンスを作成する
            Watcher = new FileSystemWatcher();
            WriterObj = new Writer(fileName);

            //監視するディレクトリを指定
            Watcher.Path = monitoringPath;

            // サブディレクトリも監視する
            Watcher.IncludeSubdirectories = true;

            //最終アクセス日時、最終更新日時、ファイル、フォルダ名の変更を監視する
            Watcher.NotifyFilter =
                (System.IO.NotifyFilters.LastAccess
                | System.IO.NotifyFilters.LastWrite
                | System.IO.NotifyFilters.FileName
                | System.IO.NotifyFilters.DirectoryName);

            //すべてのファイルを監視
            Watcher.Filter = "";

            //イベントハンドラの追加
            Watcher.Changed += new System.IO.FileSystemEventHandler(watcher_Changed);
            Watcher.Created += new System.IO.FileSystemEventHandler(watcher_Changed);
            Watcher.Deleted += new System.IO.FileSystemEventHandler(watcher_Changed);
            Watcher.Renamed += new System.IO.RenamedEventHandler(watcher_Renamed);
        }

        /// <summary>
        /// 編集された場合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void watcher_Changed(System.Object source, System.IO.FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                // 更新、または新規作成された場合
                case System.IO.WatcherChangeTypes.Changed:
                case System.IO.WatcherChangeTypes.Created:
                    lock (obj)
                    {
                        WriterObj.LineWrite(e.FullPath);
                    }
                    break;
                // 削除された場合
                case System.IO.WatcherChangeTypes.Deleted:
                    lock (obj)
                    {
                        WriterObj.LineDelete(e.FullPath);
                    }
                    break;
            }
        }
        /// <summary>
        /// 名前の変更があった場合
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void watcher_Renamed(System.Object source, System.IO.RenamedEventArgs e)
        {
            lock (obj)
            {
                WriterObj.LineChange(e.OldFullPath, e.FullPath);
            }
        }
    }    
}
