using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBackUp
{
    public partial class Form1 : Form
    {
        private const string FILE_COPY = "FileCopy";
        private const string FILE_COPY_PATH = "FileCopy.exe";

        private const string BUTTON_STOP = "stop";

        private Process[] fileCopy;

        public Form1()
        {
            InitializeComponent();

            // サービスが起動しているか確認する
            fileCopy = Process.GetProcessesByName(FILE_COPY);

            // サービスが起動している場合はボタンの文字を変更する
            if (fileCopy.Length > 0)
            {
                btnRun.Text = BUTTON_STOP;                
            }
        }

        /// <summary>
        /// start stop押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if(fileCopy.Length > 0)
            {
                // -------------
                // stopボタン押下
                // -------------
                fileCopy.First().Kill();
            }
            else
            {
                // -------------
                // startボタン押下
                // -------------
                // 別アプリの起動準備
                string backUpPath = Path.Combine(Environment.CurrentDirectory, FILE_COPY_PATH);
                ProcessStartInfo startInfo = new ProcessStartInfo(backUpPath);

                // コマンドライン引数の設定
                startInfo.Arguments = txtMaximum + "," + txtInterval + "," + txtCopyPath;
                startInfo.UseShellExecute = false;
                Process.Start(startInfo);
            }
        }

    }
}
