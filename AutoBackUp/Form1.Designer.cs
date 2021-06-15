
namespace AutoBackUp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.lblMaximum = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtMaximum = new System.Windows.Forms.TextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.txtCopyPath = new System.Windows.Forms.TextBox();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(151, 221);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(178, 41);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Start";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblMaximum
            // 
            this.lblMaximum.AutoSize = true;
            this.lblMaximum.Location = new System.Drawing.Point(17, 44);
            this.lblMaximum.Name = "lblMaximum";
            this.lblMaximum.Size = new System.Drawing.Size(77, 18);
            this.lblMaximum.TabIndex = 0;
            this.lblMaximum.Text = "Maximum";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(17, 91);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(64, 18);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Interval";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 138);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(82, 18);
            this.lblPath.TabIndex = 5;
            this.lblPath.Text = "CopyPath";
            // 
            // txtMaximum
            // 
            this.txtMaximum.Location = new System.Drawing.Point(120, 41);
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.Size = new System.Drawing.Size(54, 25);
            this.txtMaximum.TabIndex = 1;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(120, 87);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(54, 25);
            this.txtInterval.TabIndex = 3;
            // 
            // txtCopyPath
            // 
            this.txtCopyPath.Location = new System.Drawing.Point(12, 159);
            this.txtCopyPath.Name = "txtCopyPath";
            this.txtCopyPath.Size = new System.Drawing.Size(317, 25);
            this.txtCopyPath.TabIndex = 6;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(187, 91);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(66, 18);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "Minutes";
            // 
            // btnSetup
            // 
            this.btnSetup.Location = new System.Drawing.Point(12, 221);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(116, 41);
            this.btnSetup.TabIndex = 7;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 274);
            this.Controls.Add(this.txtCopyPath);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.txtMaximum);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.lblMaximum);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnRun);
            this.Name = "Form1";
            this.Text = "FileBackUP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblMaximum;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtMaximum;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.TextBox txtCopyPath;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Button btnSetup;
    }
}

