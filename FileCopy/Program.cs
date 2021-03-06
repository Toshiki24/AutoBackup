using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy
{
    class Program
    {
        private const string FILE_NAME = "paths.txt";
        private const string LOG = "log.txt";

        static void Main(string[] args)
        {
            try
            {
                //テスト用
                string copyPath = string.Empty;
                if (args.Length > 0)
                {
                    copyPath = args[0] ?? @"C:\Users\toshiki\Desktop\test";
                    LogOutput(new List<string> { "引数取れてない" });
                }
                else
                {
                    copyPath = @"C:\Users\toshiki\Desktop\test";
                }
                // コピーするファイルパスを取得する
                var paths = ReadFile();
                // ファイルをコピーする
                var errorList = Copy(copyPath, paths);
                // ログを出力する
                LogOutput(errorList);
            }
            catch (Exception ex)
            {
                LogOutput(new List<string> { ex.ToString() });
            }
        }

        /// <summary>
        /// ファイルの読み込み
        /// </summary>
        /// <param name="dirName">作業フォルダ名</param>
        private static List<string> ReadFile()
        {
            List<string> paths = new List<string>();

            // ファイル読み込み
            string csvpath = Path.Combine(Environment.CurrentDirectory, FILE_NAME);
            
            using (StreamReader reader = new StreamReader(csvpath, Encoding.GetEncoding("UTF-8")))
            {
                while(reader.Peek() != -1)
                {
                    paths.Add(reader.ReadLine());               
                }
            }
            return paths;
        }

        /// <summary>
        /// ファイルをコピーする
        /// </summary>
        /// <param name="copyList">コピー対象のパスリスト</param>
        /// <returns>コピーできなかったファイルパスリスト</returns>
        private static List<string> Copy(string outputPath, List<string> copyList)
        {
            // ファイルコピー失敗リスト
            List<string> errorList = new List<string>();
            string createPath = string.Empty;

            foreach (string path in copyList)
            {
                try
                {
                    // ドライブ名を取得
                    int index = path.IndexOf('\\');
                    string prefix = path.Substring(0, index);
                    // ドライブ名を削除して階層リスト作成
                    var underPath = path.Substring(index + 1);
                    var hierarchyList = underPath.Split('\\');

                    // ディレクトリの作成
                    createPath = outputPath;
                    int count = 1;
                    foreach (string hierarch in hierarchyList)
                    {
                        createPath = Path.Combine(createPath, hierarch);
                        // 最後の要素は処理スキップ
                        if (count == hierarchyList.Count())
                        {
                            break;
                        }
                        // フォルダが存在しない場合作成
                        if (!Directory.Exists(createPath))
                        {
                            Directory.CreateDirectory(createPath);
                        }
                        count++;
                    }
                    // ファイルのコピー
                    File.Copy(path, createPath);
                }
                catch (Exception)
                {
                    errorList.Add(path);
                    continue;
                }
            }
            return errorList;
        }

        /// <summary>
        /// ログの出力
        /// </summary>
        /// <param name="strList"></param>
        private static void LogOutput(List<string> strList)
        {
            string path = Path.Combine(Environment.CurrentDirectory, LOG);
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("UTF-8")))
            {
                foreach (string item in strList)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
