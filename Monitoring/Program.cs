using Common;
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

        public static object obj = new object();

        static async Task Main(string[] args)
        {
            // コマンドライン引数の取得
            if(args.Length > 0)
            {
                var argList = args[0].Split(',').ToList();
                Maximam = int.Parse(argList[0]);
                Interval = int.Parse(argList[1]);
                CopyPath = argList[2];
            }
            else
            {
                // テスト用
                Maximam = 2;
                Interval = 1;
                CopyPath = @"C:\Users\toshiki\Desktop\test2";
            }

            MonitoringManage manage = new MonitoringManage();
            await Task.Run(manage.StartMonitoring);
        }
    }
}
