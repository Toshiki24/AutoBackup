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
        private const string MONITORING_EXE = "Monitoring.exe";
        private const string MONITORING = "Monitoring";

        private const string BUTTON_STOP = "stop";

        private Process[] monitoring;

        public Form1()
        {
            InitializeComponent();

            // プロセスが起動しているか確認する
            monitoring = Process.GetProcessesByName(MONITORING);

            // プロセスが起動している場合はボタンの文字を変更する
            if (monitoring.Length > 0)
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
            if(monitoring.Length > 0)
            {
                // -------------
                // stopボタン押下
                // -------------
                monitoring.First().Kill();
            }
            else
            {
                // -------------
                // startボタン押下
                // -------------
                // 別アプリの起動準備
                string backUpPath = Path.Combine(Environment.CurrentDirectory, MONITORING_EXE);
                string args = txtMaximum.Text + "," + txtInterval.Text + "," + txtCopyPath.Text;
                Process.Start(backUpPath, args);
            }

            this.Close();
        }

        /// <summary>
        /// Setupボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm setupForm = new SetupForm();
            this.Visible = false;
            setupForm.ShowDialog();
            this.Visible = true;
        }
    }
}
