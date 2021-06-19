using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    class Writer
    {
        private static object obj = new object();

        public string FilePath { get; set; }
        private List<string> paths = new List<string>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName"></param>
        public Writer(string fileName)
        {
            lock (obj)
            {
                this.FilePath = Path.Combine(Environment.CurrentDirectory, fileName);
                if (!File.Exists(FilePath))
                {
                    File.Create(FilePath);
                }
                else
                {
                    paths = File.ReadAllLines(FilePath).ToList();
                }
            }
        }

        /// <summary>
        /// メモリ内の文言をテキストファイルに書き込む
        /// </summary>
        public void Write()
        {
            File.WriteAllLines(FilePath, paths);
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
                if (paths.Contains(str))
                {
                    return;
                }
                paths.Add(str);
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
                paths = paths.FindAll(x => x != str);
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

