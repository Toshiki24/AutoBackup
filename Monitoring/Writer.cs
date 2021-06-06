using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring
{
    class Writer
    {
        private object obj = new object();

        private const string CSV_FILE_NAME = "paths.csv";
        public string CSVPath { get; set; }

        public Writer()
        {
            this.CSVPath = Path.Combine(Environment.CurrentDirectory, CSV_FILE_NAME);
        }

        /// <summary>
        /// CSVファイルへの書き込み
        /// </summary>
        /// <param name="str"></param>
        public void LineWrite(string str)
        {
            // CSVファイルに書き込みたい文字列があった場合は処理終了
            List<string> lines = File.ReadAllLines(CSVPath).ToList();
            if (lines.Contains(str))
            {
                return;
            }

            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(CSVPath, false, Encoding.GetEncoding("UTF-8")))
                {
                    writer.WriteLine(str);
                }
            }
        }

        /// <summary>
        /// 行を削除する
        /// </summary>
        /// <param name="str"></param>
        public void LineDelete(string str)
        {
            lock (obj)
            {
                List<string> lines = File.ReadAllLines(CSVPath).ToList();
                lines = lines.FindAll(x => x != str);
                System.IO.File.WriteAllLines(CSVPath, lines);
            }
        }

        public void LineChange(string before,string after)
        {
            lock (this)
            {
                List<string> lines = File.ReadAllLines(CSVPath).ToList();
                if(lines.Contains(before))
                {
                    LineDelete(before);
                    LineWrite(after);
                }
            }
        }
    }
}
