using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Monitoring
{
    public class MonitoringManage
    {
        private Common.Monitoring monitoring;
        private bool stopflag = false;

        private const string FILECOPY_EXE = "FileCopy.exe";
        private const string FILECOPY_PROCESSNAME = "FileCopy";
        private const string FILENAME = "paths.txt";

        public MonitoringManage()
        {
            this.monitoring = new Common.Monitoring(FILENAME);
        }

        /// <summary>
        /// 監視開始
        /// </summary>
        public void StartMonitoring()
        {
            // 監視開始
            Start();

            while (true)
            {
                if (stopflag)
                {
                    Stop();
                    monitoring.WriterObj.Write();
                    // ----------------------
                    // コピーアプリを起動する
                    // ----------------------
                    Process process = new Process();
                    process.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory, FILECOPY_EXE);
                    process.StartInfo.Arguments = Program.CopyPath;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();
                    process.WaitForExit();

                    Start();
                }
                else
                {
                    Task.Delay(2000);
                }
            }
        }

        /// <summary>
        /// 監視開始
        /// </summary>
        private void Start()
        {
            // 監視開始
            monitoring.Watcher.EnableRaisingEvents = true;

        }

        /// <summary>
        /// 監視終了
        /// </summary>
        public void Stop()
        {
            monitoring.Watcher.EnableRaisingEvents = false;
        }
    }
}
