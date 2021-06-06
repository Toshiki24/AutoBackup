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
        private const string CSV_FILE_NAME = "paths.csv";

        static void Main(string[] args)
        {
            // コピーするファイルパスを取得する
            var paths = ReadFile();
            // ファイルをコピーする
            var errorList = Copy(args[0],paths);
        }

        /// <summary>
        /// CSVファイルの読み込み
        /// </summary>
        /// <param name="dirName">作業フォルダ名</param>
        private static List<string> ReadFile()
        {
            List<string> paths = new List<string>();

            // CSVファイル読み込み
            string csvpath = Path.Combine(Environment.CurrentDirectory, CSV_FILE_NAME);
            
            using (StreamReader reader = new StreamReader(csvpath, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                paths = reader.ReadToEnd().Split(',').ToList();               
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
    }
}
