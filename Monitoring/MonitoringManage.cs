using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitoring
{
    public class MonitoringManage
    {
        private Monitoring monitoring;
        private bool stopflag = false;

        private const string FILECOPY_EXE = "FileCopy.exe";
        private const string FILECOPY_PROCESSNAME = "FileCopy";


        public MonitoringManage()
        {
            this.monitoring = new Monitoring();
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
