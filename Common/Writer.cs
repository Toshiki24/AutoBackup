using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class Writer
    {
        private object obj = new object();

        public string FilePath { get; set; }

        public Writer(string fileName)
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory, fileName);
            if(!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }

        /// <summary>
        /// CSVファイルへの書き込み
        /// </summary>
        /// <param name="str"></param>
        public void LineWrite(string str)
        {
            // 自身が対象の場合は処理終了
            if (str == FilePath)
                return;

            lock (obj)
            {
                // ファイルに書き込みたい文字列があった場合は処理終了
                List<string> lines = File.ReadAllLines(FilePath).ToList();
                if (lines.Contains(str))
                {
                    return;
                }

                File.AppendAllText(FilePath,str + Environment.NewLine);
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
                List<string> lines = File.ReadAllLines(FilePath).ToList();
                lines = lines.FindAll(x => x != str);
                File.WriteAllLines(FilePath, lines);
            }
        }

        public void LineChange(string before,string after)
        {
            lock (this)
            {
                List<string> lines = File.ReadAllLines(FilePath).ToList();
                if(lines.Contains(before))
                {
                    LineDelete(before);
                    LineWrite(after);
                }
            }
        }
    }
}

