using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring
{
    class Program
    {
        public static int Maximam { get; set; }
        public static int Interval { get; set; }
        public static string CopyPath { get; set; }

        static void Main(string[] args)
        {
            // コマンドライン引数の取得
            var argList = args[0].Split('\\').ToList();
            Maximam = int.Parse(argList[0]);
            Interval = int.Parse(argList[1]);
            CopyPath = argList[3];
            MonitoringManage manage = new MonitoringManage();
            manage.StartMonitoring();
        }
    }
}
