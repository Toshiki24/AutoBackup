using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBackUp
{
    public partial class SetupForm : Form
    {
        private const string FILENAME = "exclusion.txt";
        public SetupForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStart_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("こちらの画面が動いている間に更新されたファイルは監視の対象外とします。" + Environment.NewLine +
                "テキストボックスに設定した秒数はPCを操作しないでください。" + Environment.NewLine +
                "起動してもよろしいですか？", "起動確認",MessageBoxButtons.YesNo);

            if(result != DialogResult.Yes)
            {
                return;
            }

            // 数値ではない場合はリターン
            int i = 0;
            if(!int.TryParse(txtTime.Text, out i))
            {
                MessageBox.Show("数値を入力してください。　");
                return;
            }

            // コントロールの活性制御
            btnClose.Enabled = false;
            btnStart.Enabled = false;
            txtTime.Enabled = false;
            label1.Visible = true;
            lblSeconds.Visible = true;
            this.Refresh();

            // 監視開始
            Common.Monitoring monitoring = new Common.Monitoring(FILENAME);
            monitoring.Watcher.EnableRaisingEvents = true;

            // 残り時間の計算
            lblSeconds.Text = i.ToString();
            int count = 0;
            while(count < i)
            {
                // 1秒待機
                await Task.Delay(1000);
                count++;
                lblSeconds.Text = (i - count).ToString();
                this.Refresh();
            }

            // 監視終了
            monitoring.Watcher.EnableRaisingEvents = false;

            // テキストファイルへの書き込み
            monitoring.WriterObj.Write();

            // コントロールを元に戻す
            btnClose.Enabled = true;
            btnStart.Enabled = true;
            txtTime.Enabled = true;
            label1.Visible = false;
            lblSeconds.Visible = false;
        }
    }
}
